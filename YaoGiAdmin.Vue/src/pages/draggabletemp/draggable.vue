<!--AutoGenerate-->
<template>
<el-container>
    <draggable v-model="colors" @update="datadragEnd" :options="{animation:500}">
        <transition-group>
            <div v-for="element in colors" :key="element.text" class="drag-item">
                {{element.text}}
            </div>
        </transition-group>
    </draggable>
</el-container>
</template>

<script>
//这里可以导入其他文件（比如：组件，工具js，第三方插件js，json文件，图片文件等等）
//例如：import《组件名称》from'《组件路径》';
import draggable from 'vuedraggable'
export default {
    //import引入的组件需要注入到对象中才能使用
    components: {
        draggable
    },
    data() {

        //这里存放数据
        return {
            msg: "这是测试组件",
            colors: [{
                    text: "Aquamarine",
                },
                {
                    text: "Hotpink",
                },
                {
                    text: "Gold",
                },
                {
                    text: "Crimson",
                },
                {
                    text: "Blueviolet",
                },
                {
                    text: "Lightblue",
                },
                {
                    text: "Cornflowerblue",
                },
                {
                    text: "Skyblue",
                },
                {
                    text: "Burlywood",
                }
            ],
            startArr: [],
            endArr: [],
            count: 0,
        };
    },
    //监听属性类似于data概念
    computed: {},
    //监控data中的数据变化
    watch: {

    },
    //方法集合
    methods: {
        getdata(evt) {
            console.log(evt.draggedContext.element.text)
        },
        datadragEnd(evt) {
            evt.preventDefault();
            console.log('拖动前的索引 :' + evt.oldIndex)
            console.log('拖动后的索引 :' + evt.newIndex)
            console.log(this.colors);
        }
    },
    //生命周期-创建完成（可以访问当前this实例）
    created() {

    },
    //生命周期-挂载完成（可以访问DOM元素）
    mounted() {
        //为了防止火狐浏览器拖拽的时候以新标签打开，此代码真实有效
        document.body.ondrop = function (event) {
            event.preventDefault();
            event.stopPropagation();
        }
    },
    //生命周期-创建之前
    beforeCreate() {

    },
    //生命周期-挂载之前
    beforeMount() {

    },
    //生命周期-更新之前
    beforeUpdate() {

    },
    //生命周期-更新之后
    updated() {

    },
    //生命周期-销毁之前
    beforeDestroy() {

    },
    //生命周期-销毁完成
    destroyed() {

    },
    //如果页面有keep-alive缓存功能，这个函数会触发
    activated() {

    },
}
</script>

<style scoped>
/*@importurl();引入公共css类*/
</style>

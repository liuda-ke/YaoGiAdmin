<!--tempautegenerate-->
<template>
<el-container>
    <!-- <el-tree :data="data" :props="defaultProps"></el-tree> -->
    <el-col :span="24">
        <el-menu default-active="2" class="el-menu-vertical-demo" @open="handleOpen" @close="handleClose">
            <el-submenu index="1">
                <template slot="title">
                    <i class="el-icon-location"></i>
                    <span>导航一</span>
                </template>
                <el-menu-item-group>
                    <template slot="title">分组一</template>
                    <el-menu-item index="1-1" @click="JumpToPage('/HelloWorld')">选项1</el-menu-item>
                    <el-menu-item index="1-2" @click="JumpToPage('/userinfo')">选项2</el-menu-item>
                </el-menu-item-group>
                <el-menu-item-group title="分组2">
                    <el-menu-item index="1-3">选项3</el-menu-item>
                </el-menu-item-group>
                <el-submenu index="1-4">
                    <template slot="title">选项4</template>
                    <el-menu-item index="1-4-1">选项1</el-menu-item>
                </el-submenu>
            </el-submenu>
            <el-menu-item index="2">
                <i class="el-icon-menu"></i>
                <span slot="title">导航二</span>
            </el-menu-item>
            <el-menu-item index="3" disabled>
                <i class="el-icon-document"></i>
                <span slot="title">导航三</span>
            </el-menu-item>
            <el-menu-item index="4">
                <i class="el-icon-setting"></i>
                <span slot="title">导航四</span>
            </el-menu-item>
        </el-menu>
    </el-col>
</el-container>
</template>

<script>
//这里可以导入其他文件（比如：组件，工具js，第三方插件js，json文件，图片文件等等）
//例如：import《组件名称》from'《组件路径》';

export default {
    //import引入的组件需要注入到对象中才能使用
    components: {

    },
    data() {

        //这里存放数据
        return {

        };
    },
    //监听属性类似于data概念
    computed: {},
    //监控data中的数据变化
    watch: {

    },
    //方法集合
    methods: {
        handleOpen(key, keyPath) {
            console.log(key, keyPath);
        },
        handleClose(key, keyPath) {
            console.log(key, keyPath);
        },
        JumpToPage(path) {
            this.$router.push({
                path: path
            })
        }
    },
    //生命周期-创建完成（可以访问当前this实例）
    created() {

    },
    //生命周期-挂载完成（可以访问DOM元素）
    mounted() {

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
.el-tree {
    width: 100vw;
}
</style>

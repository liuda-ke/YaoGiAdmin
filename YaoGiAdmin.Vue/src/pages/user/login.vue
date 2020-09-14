<!--AutoGenerate-->

<template>
<el-container>
    <div class="images">
        <img :src="photo" alt="">
    </div>

    <el-row>
        <el-form ref="form" :model="form" label-width="80px">
            <el-form-item label="账号：">
                <el-input v-model="form.account" clearable placeholder="亲输入账号"></el-input>
            </el-form-item>
            <el-form-item label="密码：">
                <el-input v-model="form.password" show-password clearable></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="onSubmit">登录</el-button>
                <!-- <el-button>取消</el-button> -->
            </el-form-item>
        </el-form>
    </el-row>
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
            form: {
                account: '',
                password: ''
            },
            photo: require('../../../static/images/backgroundimg.jpg')

        };
    },
    //监听属性类似于data概念
    computed: {

    },
    //监控data中的数据变化
    watch: {

    },
    //方法集合
    methods: {
        onSubmit() {
            this.$message("你好")
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
.images {
    width: 100%;
    height: 100%;
}

.img {
    width: 100%;
    height: 100%;
    position: fixed;
    z-index: -10;
    background-repeat:no-repeat;   
 /* 固定背景图片位置 */  
 background-attachment:fixed;   
 /* 设定背景图片在右下角 */  
 background-position:rightright bottombottom;   
}

.el-row {
    z-index: 99999;
    width: 400px;
    height: 300px;
    position: fixed;
    top: 90%;
    left: 70%;
    margin-left: -200px;
    margin-top: -150px;

}

.el-form-item {
    color: white;
}
</style>

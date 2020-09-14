<template>
<el-container>
    <el-header>
        <label for="YaoGI后台管理">YaoGiAdmin</label>
        <img src="https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png" alt="">
        <el-dropdown>
            <i class="el-icon-arrow-down" style="margin-right: 15px"></i>
            <el-dropdown-menu slot="dropdown">
                <el-dropdown-item>个人信息</el-dropdown-item>
                <!-- <el-dropdown-item>新增</el-dropdown-item> -->
                <el-dropdown-item>退出登录</el-dropdown-item>
            </el-dropdown-menu>
        </el-dropdown>
    </el-header>
    <el-container>
        <el-aside width="200px">
            <Menu></Menu>
        </el-aside>
        <el-main>
            <el-breadcrumb separator="/">
                <el-breadcrumb-item :to="{ path: '/Table' }">首页</el-breadcrumb-item>
                <el-breadcrumb-item :to="{path:'/userinfo'}">活动管理</el-breadcrumb-item>
                <el-breadcrumb-item :to="{path:'/HelloWorld'}">活动列表</el-breadcrumb-item>
                <el-breadcrumb-item>活动详情</el-breadcrumb-item>
            </el-breadcrumb>
            <router-view></router-view>
        </el-main>
    </el-container>
</el-container>
</template>

<script>
//这里可以导入其他文件（比如：组件，工具js，第三方插件js，json文件，图片文件等等）
//例如：import《组件名称》from'《组件路径》';
import icon from '../pages/system/icon'
import Menu from '../pages/system/menutree'
export default {
    //import引入的组件需要注入到对象中才能使用
    components: {
        Menu
    },
    data() {
        //这里存放数据
        return {

        }
    },
    //监听属性类似于data概念
    computed: {

    },
    //监控data中的数据变化
    watch: {

    },
    //方法集合
    methods: {

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

<style>
.el-header {
    background-color: #3c8dbc;
    color: #333;
    height: 58px;
    line-height: 58px;
}

.el-header label {
    background-color: #367fa9;
    display: block;
    width: 200px;
    float: left;
    position: fixed;
    left: 0;
    cursor: pointer;
}

.el-header img {
    width: 45px;
    border-radius: 50%;
    margin: 5px 20px 0px 0px;
    float: right;
}

.el-dropdown {
    float: right;
    margin-right: -85px;
    color: white;
}

.el-main {
    height: 94vh;
    display: block;
    -webkit-box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1) inset;
    box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1) inset;
    overflow-x: visible;
    padding: 10px;
    margin: 0;
}

.el-aside {
    background-color: #fbfbfb;
    width: 200px;
    height: 94vh;
}
.router-view{
    margin-top: 10px;
}
.el-breadcrumb{
   margin: 0px 0px 10px 3px;
}
</style>

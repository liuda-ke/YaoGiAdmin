<!--AutoGenerate-->
<template>
<el-container>
<el-table :data="tableData" border style="width: 800px">
    <el-table-column fixed prop="date" label="日期" width="150">
    </el-table-column>
    <el-table-column prop="name" label="姓名" width="120">
    </el-table-column>
    <el-table-column prop="province" label="省份" width="120">
    </el-table-column>
    <el-table-column prop="city" label="市区" width="120">
    </el-table-column>
    <el-table-column prop="address" label="地址" width="300">
    </el-table-column>
    <el-table-column prop="zip" label="邮编" width="120">
    </el-table-column>
    <el-table-column fixed="right" label="操作" width="100">
        <template slot-scope="scope">
            <el-button @click="handleClick(scope.row)" type="text" size="small">查看</el-button>
            <el-button type="text" size="small" @click="handleEdit(scope.row)">编辑</el-button>
        </template>
    </el-table-column>
</el-table>
</el-container>
</template>

<script>
//这里可以导入其他文件（比如：组件，工具js，第三方插件js，json文件，图片文件等等）
//例如：import《组件名称》from'《组件路径》';
import message from '../../utils/Message'
import eventarray from '../../utils/event'
import inputs from '../tools/input'
export default {
    //import引入的组件需要注入到对象中才能使用
    components: {
        
    },
    data() {

        //这里存放数据
        return {
            tableData: [{
                date: '2016-05-02',
                name: '王小虎',
                province: '上海',
                city: '普陀区',
                address: '上海市普陀区金沙江路 1518 弄',
                zip: 200333
            }, {
                date: '2016-05-04',
                name: '王小虎',
                province: '上海',
                city: '普陀区',
                address: '上海市普陀区金沙江路 1517 弄',
                zip: 200333
            }, {
                date: '2016-05-01',
                name: '王小虎',
                province: '上海',
                city: '普陀区',
                address: '上海市普陀区金沙江路 1519 弄',
                zip: 200333
            }, {
                date: '2016-05-03',
                name: '王小虎',
                province: '上海',
                city: '普陀区',
                address: '上海市普陀区金沙江路 1516 弄',
                zip: 200333
            }]
        };
    },
    //监听属性类似于data概念
    computed: {},
    //监控data中的数据变化
    watch: {

    },
    //方法集合
    methods: {
        handleClick(row) {
            console.log(row);
            this.$message('nihao')
        },
        handleEdit(row) {
            message.handleConfirm("确认删除吗？", 'warning').then(res => {
                console.log("then");
                console.log(res);
            }).catch(res => {
                console.log("catch");
                console.log(res);
            });
            // this.$confirm("此操作将永久删除该文件, 是否继续?", "提示", {
            //     confirmButtonText: "确定",
            //     cancelButtonText: "取消",
            //     type: 'warning'
            // }).then(() => {
            //     this.$message({
            //         type: 'success',
            //         message: '删除成功!'
            //     });
            // }).catch(() => {
            //     this.$message({
            //         type: 'info',
            //         message: '已取消删除'
            //     });
            // });
        }

    },
    //生命周期-创建完成（可以访问当前this实例）
    created() {
        eventarray.mousedown();
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
</style>

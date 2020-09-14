<!--AutoGenerate-->
<template>
<el-container>
   <el-button
    plain
    @click="open1">
    可自动关闭
  </el-button>
  <el-button
    plain
    @click="open2">
    不会自动关闭
    </el-button>
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
          labelPosition: 'right',
        formLabelAlign: {
          name: '',
          region: '',
          type: ''
        }
        };
    },
    //监听属性类似于data概念
    computed: {},
    //监控data中的数据变化
    watch: {

    },
    //方法集合
    methods: {
      open1() {
        const h = this.$createElement;

        this.$notify({
          title: '标题名称',
          message: h('i', { style: 'color: teal'}, '这是提示文案这是提示文案这是提示文案这是提示文案这是提示文案这是提示文案这是提示文案这是提示文案')
        });
      },

      open2() {
        this.$notify({
          title: '提示',
          message: '这是一条不会自动关闭的消息',
          duration: 0
        });
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
.el-container {
    width: 100%;
    height: 100%;
}

.el-form {
    width: 100%;
}
</style>

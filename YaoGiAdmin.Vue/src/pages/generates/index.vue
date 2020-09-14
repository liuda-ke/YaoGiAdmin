<template>
  <div>
    <el-form ref="elForm" :model="formData" :rules="rules" size="mini" :disabled="true" label-width="100px"
      label-position="top">
      <el-row :gutter="15">
        <el-col :span="12">
          <el-form-item label="标题" prop="title">
            <el-input v-model="formData.title" placeholder="请输入标题" clearable :style="{width: '100%'}">
            </el-input>
          </el-form-item>
        </el-col>
        <el-col :span="12">
          <el-form-item label="描述" prop="descript">
            <el-input v-model="formData.descript" placeholder="请选择下拉选择描述" clearable :style="{width: '100%'}">
            </el-input>
          </el-form-item>
        </el-col>
      </el-row>
      <el-row :gutter="15">
        <el-form-item label="多行文本" prop="descrption">
          <el-input v-model="formData.descrption" type="textarea" placeholder="请输入多行文本"
            :autosize="{minRows: 4, maxRows: 6}" :style="{width: '100%'}"></el-input>
        </el-form-item>
      </el-row>
      <el-form-item size="large">
        <el-button type="primary" @click="submitForm">提交</el-button>
        <el-button @click="resetForm">重置</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>
<script>
export default {
  components: {},
  props: [],
  data() {
    return {
      formData: {
        title: undefined,
        descript: undefined,
        descrption: undefined,
      },
      rules: {
        title: [{
          required: true,
          message: '请输入标题',
          trigger: 'blur'
        }],
        descript: [{
          required: true,
          message: '请选择下拉选择描述',
          trigger: 'blur'
        }],
        descrption: [{
          required: true,
          message: '请输入多行文本',
          trigger: 'blur'
        }],
      },
    }
  },
  computed: {},
  watch: {},
  created() {},
  mounted() {},
  methods: {
    submitForm() {
      this.$refs['elForm'].validate(valid => {
        if (!valid) return
        // TODO 提交表单
      })
    },
    resetForm() {
      this.$refs['elForm'].resetFields()
    },
  }
}

</script>
<style>
</style>

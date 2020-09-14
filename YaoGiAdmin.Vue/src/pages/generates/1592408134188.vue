<template>
  <div>
    <el-row :gutter="15">
      <el-form ref="elForm" :model="formData" :rules="rules" size="mini" :disabled="false" label-width="100px"
        label-position="top">
        <el-col :span="24">
          <el-row :gutter="15">
          </el-row>
        </el-col>
        <el-col :span="24">
          <el-row :gutter="15">
          </el-row>
        </el-col>
        <el-col :span="24">
          <el-row :gutter="15">
          </el-row>
        </el-col>
        <el-col :span="10">
          <el-form-item label="单选框组" prop="field107">
            <el-radio-group v-model="formData.field107" size="medium">
              <el-radio v-for="(item, index) in field107Options" :key="index" :label="item.value"
                :disabled="item.disabled">{{item.label}}</el-radio>
            </el-radio-group>
          </el-form-item>
        </el-col>
        <el-col :span="24">
          <el-form-item size="large">
            <el-button type="primary" @click="submitForm">提交</el-button>
            <el-button @click="resetForm">重置</el-button>
          </el-form-item>
        </el-col>
      </el-form>
    </el-row>
  </div>
</template>
<script>
export default {
  components: {},
  props: [],
  data() {
    return {
      formData: {
        field107: "",
      },
      rules: {
        field107: [{
          required: true,
          message: '单选框组不能为空',
          trigger: 'change'
        }],
      },
      field107Options: [{
        "label": "选项一",
        "value": 1
      }, {
        "label": "选项二",
        "value": 2
      }, {
        "label": "选项三",
        "value": 3
      }, {
        "label": "选项四",
        "value": 4
      }],
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

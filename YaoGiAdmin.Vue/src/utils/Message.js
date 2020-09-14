import { MessageBox } from 'element-ui'
import { Message } from 'element-ui'

export default {
    handleConfirm(text = "确定执行此操作吗？", type = 'warning') {
        return MessageBox.confirm(text, "提示", {
            confirmButtonText: '确认',
            cancelButtonText: '取消',
            type: type
        });
    }
}
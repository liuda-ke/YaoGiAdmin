export default {
    mousedown() {
        window.addEventListener("mousedown", function(event) {
            switch (event.button) {
                case 0:
                    //鼠标左键
                    console.log('鼠标左键')
                    break;
                case 1:
                    //鼠标中键（滚轮）
                    console.log('鼠标中键（滚轮）')
                    break;
                case 2:
                    //鼠标右键
                    console.log('鼠标右键')
                    break;
            }
        });
    }
}
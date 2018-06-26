export default {
    config: {
        number: 1080
    },
    init(number) {
        this.config.number = number
    },
    autoMode() {
        let self = this
        
        document.documentElement.style.fontSize = document.documentElement.clientWidth / this.config.number * 100 + 'px'

        window.onresize = function () {
            self.autoMode()
        }
    }
}
import Vue from 'vue'

const link = Vue.directive('link', {
    inserted: function (el, value) {
        el.addEventListener("click", function (e) {
            location.href = value.value.path
        })
    }
})

export {
    link
}
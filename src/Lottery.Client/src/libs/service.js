//官方地址： https://github.com/mzabriskie/axios
//文档地址：https://www.kancloud.cn/yunye/axios/234845

import Vue from 'vue'
import Qs from 'qs'

export default {
    request: function (url, data, method = 'GET', loading = true) {

        return new Promise(function (resolve, reject) {

            if (loading) {
                Vue.$vux.loading.show({
                    text: '请稍候...'
                })
            }

            let obj = {
                url: url,
                method: method
            }

            switch (method) {
                case "POST":
                    Object.assign(obj, {
                        data: data
                    })
                    break
                case "GET":
                    Object.assign(obj, {
                        params: data
                    })
                    break
                default:
                //no defaule
            }

            Vue.http(obj).then((res) => {

                if (loading) Vue.$vux.loading.hide()

                if (res.data.code != 200) {
                    return Vue.$vux.alert.show({
                        title: '提示',
                        content: res.data.msg
                    })
                }

                return resolve(res.data)

            }, (res) => {

                if (loading) Vue.$vux.loading.hide()

                Vue.$vux.alert.show({
                    title: '提示',
                    content: res
                })

                reject(res.data)
            })
        })
    }
}
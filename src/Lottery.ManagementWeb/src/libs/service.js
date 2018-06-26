//官方地址： https://github.com/mzabriskie/axios
//文档地址：https://www.kancloud.cn/yunye/axios/234845

import Vue from 'vue'
import Qs from 'qs'

export default {
    get: function (url, data, loading = true) {

        return new Promise(function (resolve, reject) {

            if (loading) {
                Vue.$Message.loading({
                    content: '请稍候...',
                    duration: 0
                })
            }

            Vue.http({
                url: url,
                params: data
            }).then((res) => {

                setTimeout(() => {
                    Vue.$Message.destroy()
                }, 300)

                //TODO: 请求失败可在这进行统一处理

                resolve(res.data)
            }, (res) => {
                Vue.$Message.destroy()
                reject(res.data)
            })
        })
    },
    post: function (url, data, loading = true) {

        return new Promise(function (resolve, reject) {

            if (loading) {
                Vue.$Message.loading({
                    content: '请稍候...',
                    duration: 0
                })
            }

            Vue.http({
                url: url,
                method: 'POST',
                headers: {
                    "X-Requested-With": "XMLHttpRequest",
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                data: Qs.stringify(data)
            }).then((res) => {

                setTimeout(() => {
                    Vue.$Message.destroy()
                }, 300)

                //TODO: 请求失败可在这进行统一处理

                resolve(res.data)
            }, (res) => {
                Vue.$Message.destroy()
                reject(res.data)
            })
        })
    }
}
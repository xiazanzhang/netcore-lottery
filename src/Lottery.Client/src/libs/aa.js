import wepy from 'wepy'

export default {
    isLogin: false,
    baseUrl: "https://test-jiating-api.wanshifu.com/sysm",
    version: 'v1.0.9',
    //baseUrl: "https://dev-jiating-api.wanshifu.com",
    //baseUrl: "https://jiating-api.wanshifu.com/sysm",
    //baseUrl: "http://192.168.1.96:8085",
    //baseUrl: "http://192.168.1.116:8082",
    request(obj, loading = true) {

        wx.showNavigationBarLoading()

        if (loading && obj.method != undefined) {
            wx.showLoading({
                title: '正在加载...'
            })
        }

        let self = this
        let login = wx.getStorageSync('login')

        wx.request({
            url: obj.url,
            data: obj.data,
            method: obj.method || 'GET',
            header: {
                'content-type': 'application/x-www-form-urlencoded',
                'token': login.token
            },
            dataType: obj.dataType || "json",
            success: function (res) {
                if (obj.success) {
                    //微信响应状态码
                    if (res.statusCode == 200) {
                        //服务器后台响应状态码
                        if (res.data.code != 200) {
                            //token过期
                            if (res.data.code == 600) {
                                self.login().then(() => {
                                    self.request(obj, loading)
                                })
                            } else {
                                wx.showModal({
                                    title: '提示 (' + res.data.code + ')',
                                    content: res.data.msg,
                                    showCancel: false
                                })
                            }
                        } else {
                            return obj.success(res.data)
                        }
                    } else {
                        wx.showModal({
                            title: '状态码 (' + res.statusCode + ')',
                            content: res.data,
                            showCancel: false
                        })
                    }
                }
            },
            fail: function (res) {
                wx.showModal({
                    title: '系统错误',
                    content: res.errMsg,
                    showCancel: false
                })
            },
            complete: function (res) {
                setTimeout(() => {
                    wx.hideNavigationBarLoading()

                    if (loading && obj.method != undefined) {
                        wx.hideLoading()
                    }

                }, 500)

                if (obj.complete) {
                    return obj.complete(res)
                }
            }
        })
    },
    login() {
        return new Promise((resolve, reject) => {
            let self = this

            wx.login({
                success: (res) => {
                    wx.request({
                        url: self.baseUrl + '/wxuser/login',
                        data: {
                            code: res.code
                        },
                        header: {
                            'content-type': 'application/x-www-form-urlencoded'
                        },
                        method: 'POST',
                        success: function (res) {
                            self.isLogin = false
                            //登陆信息
                            wx.setStorageSync('login', {
                                phoneBind: res.data.phoneBind,
                                token: res.data.token,
                                time: Date.parse(new Date()) / 1000
                            })

                            return resolve()
                        }
                    })
                }
            })
        })
    },
}
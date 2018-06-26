import httpService from '@/libs/service'

export default {
    register: (data) => {
        return httpService.request('/api/user/register', data, 'POST')
    },
    login: (data) => {
        return httpService.request('/api/user/login', data, 'POST')
    },
    getUserInfo: (data) => {
        return httpService.request('/api/user/getUserInfo', data)
    }
}
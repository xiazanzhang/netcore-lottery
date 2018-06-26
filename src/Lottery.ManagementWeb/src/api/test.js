import httpService from '@/libs/service'

export default {
    joke: function (data) {
        return httpService.get('/joke', data)
    }
}
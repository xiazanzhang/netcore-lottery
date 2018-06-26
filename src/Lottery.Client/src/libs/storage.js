export default {
    sessionStorage: {
        setItem(key, value) {
            return window.sessionStorage.setItem(key, JSON.stringify(value))
        },
        getItem(key) {
            return JSON.parse(window.sessionStorage.getItem(key)) || null
        }
    }
}
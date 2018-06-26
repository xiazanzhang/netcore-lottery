import ModalComponent from 'iview/src/components/modal'
import MessageComponent from 'iview/src/components/message'
import NoticeComponent from 'iview/src/components/notice'

export default {
    install(Vue, options) {
        Vue.$Modal = ModalComponent
        Vue.$Message = MessageComponent
        Vue.$Notice = NoticeComponent
    }
}
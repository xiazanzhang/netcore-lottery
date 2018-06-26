<template>
    <div>
        <group title="请填写以下信息">
            <x-input title="用户名 " :min="4" :max="14" v-model="model.account" required placeholder="请输入4-11位英文字母或数字组合"></x-input>
            <x-input title="密码  " type="password" :min="6" :max="12" v-model="model.password" required placeholder="请输入6-12位英文字母或数字组合"></x-input>
            <x-input title="真实姓名" v-model="model.realname" required placeholder="须与出款银行户名一致"></x-input>
            <x-input title="取款密码" type="password" v-model="model.cardPassword" required placeholder="请输入6位取款密码"></x-input>
            <x-input title="手机号码" v-model="model.mobile" required placeholder="仅作为短信彩金联系方式"></x-input>
            <x-input title="介绍人 " v-model="model.introducer" placeholder="可不填"></x-input>
        </group>

        <box gap="10px 10px">
            <divider>
                我已阅读用户协议
            </divider>
            <group>
                <x-button @click.native="submit">确认提交</x-button>
            </group>
        </box>
    </div>
</template>

<script>
import { Group, XInput, XButton, Box, Divider } from "vux";
export default {
  components: {
    Group,
    XInput,
    XButton,
    Box,
    Divider
  },
  data() {
    return {
      model: {
        account: "test01",
        password: "123456",
        realname: "张三",
        cardPassword: "123456",
        mobile: "",
        introducer: "里斯"
      }
    };
  },
  methods: {
    submit() {
      let self = this;

      if (!/^[0-9A-Za-z]{4,11}$/.test(this.model.account)) {
        return this.$vux.toast.text("用户名必须是4-11位英文字母或数字组合");
      }

      if (!/^[0-9A-Za-z]{6,12}$/.test(this.model.password)) {
        return this.$vux.toast.text("密码必须是6-12位英文字母或数字组合");
      }

      if (!/^[\u4E00-\u9FA5\uf900-\ufa2d·s]{2,20}$/.test(this.model.realname)) {
        return this.$vux.toast.text("真实姓名必须是2-20位的中文汉字");
      }

      if (!/^[0-9A-Za-z]{6}$/.test(this.model.cardPassword)) {
        return this.$vux.toast.text("取款密码必须是6位英文字母或数字组合");
      }

      if (!/^1[345678][0-9]{9}$/.test(Number(this.model.mobile))) {
        return this.$vux.toast.text("请输入合法的手机号");
      }

      this.api.register(this.model).then(res => {
        this.$vux.alert.show({
          title: "提示",
          buttonText: "去登陆",
          content: "恭喜，注册成功！",
          onHide() {
            self.$router.go(-1);
          }
        });
      });
    }
  }
};
</script>

<style>
.vux-divider {
  display: table;
  white-space: nowrap;
  height: auto;
  overflow: hidden;
  line-height: 1;
  text-align: center;
  padding: 10px 0;
  color: #666;
  font-size: 12px;
}
</style>

<template>
    <div>
        <group>
            <x-input v-model="model.account" placeholder="请输入用户名"></x-input>
            <x-input type="password" v-model="model.password" placeholder="请输入密码"></x-input>
        </group>
        <box gap="10px 10px">
            <div class="link">
                <div>修改密码</div>
                <div @click="register">注册</div>
            </div>
            <group>
                <x-button @click.native="login">立即登陆</x-button>
            </group>
        </box>
    </div>
</template>

<script>
import { Group, XInput, XButton, Box } from "vux";

export default {
  components: {
    Group,
    XInput,
    XButton,
    Box
  },
  data() {
    return {
      model: {
        account: "",
        password: ""
      }
    };
  },
  methods: {
    login() {
      let self = this;

      this.api.login(this.model).then(res => {
        this.storage.sessionStorage.setItem("userInfo",res.data);
        this.$vux.toast.show({
          text: "登陆成功",
          isShowMask: true,
          onHide() {
            self.$router.go(-1);
          }
        });
      });
    },
    register() {
      this.$router.push({ path: "/center/register" });
    }
  }
};
</script>

<style>
.login {
  overflow: hidden;
  width: 6.9rem;
  height: 200px;
  padding: 0.3rem;
  background: #fff;
  border-radius: 25px;
}

.link {
  overflow: hidden;
  font-size: 14px;
  color: #737373;
  padding: 0 6px;
}

.link div {
  width: 50%;
  float: left;
}

.link div:nth-child(2) {
  text-align: right;
}
</style>
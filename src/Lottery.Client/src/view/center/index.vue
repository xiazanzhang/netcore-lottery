<template>
    <div>
        <div class="header">
            <img src="@/assets/icons/icon_11.png" alt="">
            <p v-if="userName==''" @click="login">登陆/注册</p>
            <p v-else>{{userName}}</p>
        </div>
        <group>
            <grid>
                <grid-item label="Grid">
                    <img slot="icon" src="@/assets/icons/icon_12.png">
                    <p slot="label">充值</p>
                </grid-item>
                <grid-item label="Grid">
                    <img slot="icon" src="@/assets/icons/icon_13.png">
                    <p slot="label">提现</p>
                </grid-item>
            </grid>
        </group>
        <group>
            <cell title="推广赚钱" is-link></cell>
            <cell title="投注记录" is-link></cell>
            <cell title="账户明细" is-link></cell>
            <cell title="充值记录" is-link></cell>
            <cell title="提款记录" is-link></cell>
            <cell title="常见问题" is-link></cell>
            <cell title="结算报表" is-link></cell>
            <cell title="玩法规则" is-link></cell>
            <cell title="系统设置" is-link></cell>
        </group>
    </div>
</template>

<script>
import { Group, Cell, Grid, GridItem } from "vux";

export default {
  components: {
    Group,
    Cell,
    Grid,
    GridItem
  },
  data() {
    return {
      userName: ""
    };
  },
  mounted() {
    let userInfo = this.storage.sessionStorage.getItem("userInfo");

    if (userInfo) {
      this.userName = userInfo.account;
    }
  },
  methods: {
    login() {
      this.$router.push({
        path: "/center/login"
      });
    }
  }
};
</script>

<style>
.header {
  position: relative;
  background: #fff;
  width: 100%;
  overflow: hidden;
  text-align: center;
  font-size: 16px;
  padding: 50px 0;
}

.header::after {
  content: " ";
  position: absolute;
  left: 0;
  bottom: 0;
  right: 0;
  height: 1px;
  border-bottom: 1px solid #d9d9d9;
  color: #d9d9d9;
  -webkit-transform-origin: 0 100%;
  transform-origin: 0 100%;
  -webkit-transform: scaleY(0.5);
  transform: scaleY(0.5);
}

.header p {
  margin-top: 10px;
  color: #101010;
}

.header img {
  width: 80px;
  height: 80px;
  border-radius: 50%;
  border: 1px solid #c0bfc4;
}
</style>

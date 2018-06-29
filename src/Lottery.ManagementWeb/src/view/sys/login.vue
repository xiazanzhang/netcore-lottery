<template>
    <div class="login">
        <div class="login-content">
            <Form ref="formCustom" :model="formCustom" :rules="ruleCustom">
                <FormItem label="账户" prop="account">
                    <Input v-model="formCustom.account"></Input>
                </FormItem>
                <FormItem label="密码" prop="password">
                    <Input type="password" v-model="formCustom.password"></Input>
                </FormItem>
                <FormItem>
                    <Button type="primary" @click="handleSubmit('formCustom')">登陆</Button>
                </FormItem>
            </Form>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        const validateAccount = (rule, value, callback) => {
            if (value === "") {
                callback(new Error("请输入登陆账户"));
            } else {
                callback();
            }
        };

        const validatePass = (rule, value, callback) => {
            if (value === "") {
                callback(new Error("请输入登陆密码"));
            } else {
                callback();
            }
        };

        return {
            formCustom: {
                account: "",
                password: ""
            },
            ruleCustom: {
                account: [{ validator: validateAccount, trigger: "blur" }],
                password: [{ validator: validatePass, trigger: "blur" }]
            }
        };
    },
    methods: {
        handleSubmit(name) {
            this.$refs[name].validate(valid => {
                if (valid) {
                    this.$Message.success("Success!");
                }
            });
        }
    }
};
</script>

<style scoped>
.login {
    position: absolute;
    top: 50%;
    height: 300px;
    width: 100%;
    margin-top: -150px;
    border-radius: 8px;
}

.login-content {
    height: 300px;
    width: 500px;
    padding: 30px;
    background: #fff;
    margin: 0 auto;
    box-shadow: 0px 0px 10px #d9d9d9;
    border: 1px solid #d9d9d9;
}
</style>
  
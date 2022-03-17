# TyporaWordPressImageUploader

[English](/README.md) 简体中文 

TyporaWordPressImageUploader 是一个基于 .Net Core 3.1 的 C# 应用，它允许你通过 Typora 的自定义命令行图片上传器将你的本地图片自动上传到你的 WordPress 媒体中并在 Markdown 代码中以远程链接显示。

## 安装并部署

### 在 WordPress 上

你需要跟随以下步骤来启用 WordPress Rest API 的 JWT 验证，这样我们才能为你上传图片。

1. 安装 [JWT Authentication for WP REST API](https://wordpress.org/plugins/jwt-authentication-for-wp-rest-api/) 插件到你的 WordPress 上
2. 确保你已经正确安装了这个插件，并且已经按照上方的链接正确配置，尤其是完成了 CONFIGURATE THE SECRET KEY （配置安全密钥）这一项。
3. 接下来，你需要在你的本地计算机上做一些事情。

### 在 Typora 上

我们提供了两种方式用于验证，但是我们建议使用第一种因为第二种好像有点问题 :(

#### 使用 token 进行验证

首先，向你的 WordPress Rest API 端点发送一个 post 请求，就像这样：

```HTTP
POST https://{你的 WordPress 地址}/wp-json/jwt-auth/v1/token
Content-Type: application/json

{
  "username": "{你的用户名}",
  "password": "{你的密码}"
}
```

然后你将收到一个包含 token 的 JSON 相应:

```JSON
{
  "token": "{你的 token}",
  "user_email": "...",
  "user_nicename": "...",
  "user_display_name": "..."
}
```

现在。打开 Typora，前往 `首选项 - 图像 - 图像上传设置`，将 `图片上传器` 选择为 `自定义命令行`，然后再下方的 `命令` 文本域中写入以下内容：

```Shell
"path-to-TyporaWordPressImageUploader.exe" "https://{你的 WordPress 地址}/wp-json" Bearer {你的 token}
```

接下来，点击 `测试上传` 按钮来检测连接是否正常。

下一次，当你需要在 Typora 上使用一个本地图片时，你只需要将其拖到主窗口中，然后点击 "上传图像"，图片就会自动上传到你的 WordPress 中了！

#### 使用用户名和密码进行验证

使用用户名和密码进行验证十分容易，你只需要像前面一样来到 Typora 的相同位置，然后在 `命令` 文本域中写入：

```Shell
"path-to-TyporaWordPressImageUploader.exe" "https://{你的 WordPress 地址}/wp-json" Basic {你的用户名} {你的密码}
```

## 使用的依赖库

- [WordPressPCL](https://github.com/wp-net/WordPressPCL)

## 开源协议

TyporaWordPressImageUploader 基于 [Apache License 2.0](/LICENSE.txt) 开源.


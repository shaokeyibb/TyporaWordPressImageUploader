# TyporaWordPressImageUploader

English [简体中文](/README_CN.md) 

TyporaWordPressImageUploader is a C# Application based on .Net Core 3.1 and allow you automatically upload your local images to your WordPress and show them as a remote link in Markdown by using the custom command image upload in Typora. 

## Install and Deploy

### On WordPress

You need to following these steps to enable the JWT authentication for the WordPress Rest API, and so we can upload the images.

1. Install [JWT Authentication for WP REST API](https://wordpress.org/plugins/jwt-authentication-for-wp-rest-api/) to your WordPress
2. Make sure you have installed JWT Authentication for WP REST API plugin, and configurated it by following the link above. especially finished the CONFIGURATE THE SECRET KEY.
3. That's all, and now you need to do something in your local machine.

### On Typora

We have two ways for you to authentication, but we recommend first one because the another one may have broken.

#### Authenticate with token

First, send a post request to your WordPress Rest API endpoint like this:

```HTTP
POST https://{your wordpress domain here}/wp-json/jwt-auth/v1/token
Content-Type: application/json

{
  "username": "{your username}",
  "password": "{your password}"
}
```

And you will receive a JSON response contains your token:

```JSON
{
  "token": "{your token here}",
  "user_email": "...",
  "user_nicename": "...",
  "user_display_name": "..."
}
```

And now, open the Typora, go to `Preference - Image - Image Upload Setting`, select the `Image Uploader` to `Custom Command`, then type these in the `Command` text field:

```Shell
"path-to-TyporaWordPressImageUploader.exe" "https://{your wordpress domain here}/wp-json" Bearer {your token here}
```

Next, press the `Test Uploader` button to check the connection is ok. 

And that's all, next when you need to use a local image in the Typora, just drag it to the main window, and press "Upload Image", and then the image will automatically upload to your WordPress!

#### Authenticate with username and password

Authenticate with username and password is very simple, you can just directly go to the same way in Typora like above, and in the `Command` text field type:

```Shell
"path-to-TyporaWordPressImageUploader.exe" "https://{your wordpress domain here}/wp-json" Basic {your username here} {your password here}
```

## Libraries Used

- [WordPressPCL](https://github.com/wp-net/WordPressPCL)

## License

TyporaWordPressImageUploader is licensed under the [Apache License 2.0](/LICENSE.txt).

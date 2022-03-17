# TyporaWordPressImageUploader

[English](/README.md) �������� 

TyporaWordPressImageUploader ��һ������ .Net Core 3.1 �� C# Ӧ�ã���������ͨ�� Typora ���Զ���������ͼƬ�ϴ�������ı���ͼƬ�Զ��ϴ������ WordPress ý���в��� Markdown ��������Զ��������ʾ��

## ��װ������

### �� WordPress ��

����Ҫ�������²��������� WordPress Rest API �� JWT ��֤���������ǲ���Ϊ���ϴ�ͼƬ��

1. ��װ [JWT Authentication for WP REST API](https://wordpress.org/plugins/jwt-authentication-for-wp-rest-api/) �������� WordPress ��
2. ȷ�����Ѿ���ȷ��װ���������������Ѿ������Ϸ���������ȷ���ã������������ CONFIGURATE THE SECRET KEY �����ð�ȫ��Կ����һ�
3. ������������Ҫ����ı��ؼ��������һЩ���顣

### �� Typora ��

�����ṩ�����ַ�ʽ������֤���������ǽ���ʹ�õ�һ����Ϊ�ڶ��ֺ����е����� :(

#### ʹ�� token ������֤

���ȣ������ WordPress Rest API �˵㷢��һ�� post ���󣬾���������

```HTTP
POST https://{��� WordPress ��ַ}/wp-json/jwt-auth/v1/token
Content-Type: application/json

{
  "username": "{����û���}",
  "password": "{�������}"
}
```

Ȼ���㽫�յ�һ������ token �� JSON ��Ӧ:

```JSON
{
  "token": "{��� token}",
  "user_email": "...",
  "user_nicename": "...",
  "user_display_name": "..."
}
```

���ڡ��� Typora��ǰ�� `��ѡ�� - ͼ�� - ͼ���ϴ�����`���� `ͼƬ�ϴ���` ѡ��Ϊ `�Զ���������`��Ȼ�����·��� `����` �ı�����д���������ݣ�

```Shell
"path-to-TyporaWordPressImageUploader.exe" "https://{��� WordPress ��ַ}/wp-json" Bearer {��� token}
```

����������� `�����ϴ�` ��ť����������Ƿ�������

��һ�Σ�������Ҫ�� Typora ��ʹ��һ������ͼƬʱ����ֻ��Ҫ�����ϵ��������У�Ȼ���� "�ϴ�ͼ��"��ͼƬ�ͻ��Զ��ϴ������ WordPress ���ˣ�

#### ʹ���û��������������֤

ʹ���û��������������֤ʮ�����ף���ֻ��Ҫ��ǰ��һ������ Typora ����ͬλ�ã�Ȼ���� `����` �ı�����д�룺

```Shell
"path-to-TyporaWordPressImageUploader.exe" "https://{��� WordPress ��ַ}/wp-json" Basic {����û���} {�������}
```

## ʹ�õ�������

- [WordPressPCL](https://github.com/wp-net/WordPressPCL)

## ��ԴЭ��

TyporaWordPressImageUploader ���� [Apache License 2.0](/LICENSE.txt) ��Դ.


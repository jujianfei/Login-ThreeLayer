1.判断是否存在？如不存在给出提示。
2.判断密码是否正确？如不正确给出提示。
3.判断登录失败次数是否大于三次，如果大于三次则禁止15分钟。

要求：
1.窗体居中显示，隶书，三号。
2.设置MDI主窗体。
3.控件设置可以很好识别的英文名。驼峰标识法。
4.控件在窗体中居中显示（格式）。
5.TabIndex属性的值从左到右，从上到下的顺序排好。
6.有按钮的窗体设置默认的按钮（acceptButton）。

业务分析：
1.UI层获取数据，和给出提示，如果出错，要求能判断是用户名错还是密码错。
2.BLL层判断用户信息是否正确，并判断是否登录错误次数超过3次。
3.DAL对数据库进行增删改查，将结果返回给BLL层。


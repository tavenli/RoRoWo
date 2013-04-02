RoRoWo
======

C#的萝萝窝个人博客开源项目，从Codeplex转移过来

之前开源地址:http://rorowo.codeplex.com

-----------------------------------------------------


萝萝窝个人博客开源项目

以Asp.net MVC 2.0 + ADO.Net Entity Framework 4.0 + Unity 2.0 + MvcPager + JQuery 等技术框架，开发的个人博客系统。
 
 
//重要更新日志
2010-10-9
我这次国庆的时间  主要改了以下内容：
1、改为POCO，使EF的实体纯净
2、增加 IoCHelper类，把IoC的代码改为可以同时支持多种IoC
3、修改基础结构层，使其可以支持多种ORM框架
4、修正继承自 DefaultControllerFactory 的自定义控制器，使MVC控制器可以支持依赖注入，充分发挥IoC自动装载的特性
5、正式启用规约接口 ISpecification 作为查询条件

 
要创建数据库，请在 RoRoWo.Blog.Infrastructure 打开 RoRoWoDB.edmx 模型视图，在视图显示页面中，点击鼠标右键，选择 “根据模型生成数据库”可以得到创建数据库的SQL，然后修改相关Config中的数据库连接字符串就可以了。
 
数据库默认是SQL SERVER 2008,如果您是2005的，请用记事本打开 RoRoWoDB.edmx 文件，将 ProviderManifestToken="2008" 修改为 ProviderManifestToken="2005" ，否则插入数据的操作会出现问题。
 
 
支持MetaWeblog接口
通过MetaWeblog接口，可以将您个人博客系统中的博文，直接同步到您其它网站的博客中。比如www.cnblogs.com就支持MetaWeblog接口，只要设置博客园的相应帐号信息，即可实现在自己的个人博客系统中发布，系统自动同步到博客园的相应博客中。
 
 
   
项目发起人：李锡远
我的技术博客：http://taven.cnblogs.com



系统部分页面预览：

![1.jpg](https://raw.github.com/tavenli/RoRoWo/master/Screenshots/1.jpg)

![1.jpg](https://raw.github.com/tavenli/RoRoWo/master/Screenshots/2.jpg)

![1.jpg](https://raw.github.com/tavenli/RoRoWo/master/Screenshots/3.jpg)

![1.jpg](https://raw.github.com/tavenli/RoRoWo/master/Screenshots/3_2.jpg)




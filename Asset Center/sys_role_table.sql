USE Remark
GO
/****** Object:  Table [dbo].[SYS_AUTHORITIE]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_AUTHORITIE](
	[ID] [numeric](8, 0) NOT NULL,
	[NAME] [varchar](400) NULL,
	[DISPLAY_NAME] [varchar](400) NULL,
	[PARENT_ID] [numeric](8, 0) NULL,
 CONSTRAINT [PRI_AUTHORITIES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_LOG]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_LOG](
	[LOG_CODE] [numeric](18, 0) NOT NULL,
	[PSN_CODE] [numeric](18, 0) NULL,
	[LOG_TYPE] [varchar](40) NULL,
	[KEY_CODE] [varchar](200) NULL,
	[CREATE_DATE] [datetime] NOT NULL,
	[LOG_ACTION] [varchar](2000) NULL,
	[LOG_DETAIL] [text] NULL,
	[CLIENT_IP] [varchar](30) NULL,
	[SERVER_IP] [varchar](300) NULL,
	[EXCEPTION] [text] NULL,
	[USER_AGENT] [varchar](1000) NULL,
 CONSTRAINT [PK_SYS_LOG] PRIMARY KEY CLUSTERED 
(
	[LOG_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_ORG]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_ORG](
	[ID] [numeric](18, 0) NOT NULL,
	[ORG_CODE] [numeric](18, 0) NULL,
	[SYS_ID] [numeric](18, 0) NULL,
	[STATUS] [varchar](1) NULL,
	[REQUEST_PSN_CODE] [numeric](18, 0) NULL,
	[REQUEST_TIME] [datetime] NULL,
	[CONFIRM_PSN_CODE] [numeric](18, 0) NULL,
	[CONFIRM_TIME] [datetime] NULL,
	[INFO_STATUS] [varchar](1) NULL DEFAULT ('Z'),
 CONSTRAINT [SYS_C0031635] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_PLATFORM_ROLE]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_PLATFORM_ROLE](
	[ROLE_ID] [numeric](18, 0) NULL,
	[PLATFORM_ROLE] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SYS_PSN_INFO]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_PSN_INFO](
	[ID] [numeric](18, 0) NOT NULL,
	[SYS_ID] [numeric](18, 0) NULL,
	[PSN_CODE] [numeric](18, 0) NULL,
	[ORG_CODE] [numeric](18, 0) NULL,
	[ROLE_ID] [numeric](18, 0) NULL,
	[STATUS] [numeric](1, 0) NULL DEFAULT ((1)),
 CONSTRAINT [PK_SYS_PSN_INFO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UNI_SYS_PSN_INFO] UNIQUE NONCLUSTERED 
(
	[SYS_ID] ASC,
	[PSN_CODE] ASC,
	[ORG_CODE] ASC,
	[ROLE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SYS_PSN_KEYCODE]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_PSN_KEYCODE](
	[SYS_PSN_ID] [numeric](18, 0) NOT NULL,
	[KEY_CODE] [numeric](18, 0) NOT NULL,
	[TYPE] [numeric](2, 0) NOT NULL,
 CONSTRAINT [PK_SYS_PSN_KEYCODE] PRIMARY KEY CLUSTERED 
(
	[SYS_PSN_ID] ASC,
	[KEY_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SYS_RESOURCE]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_RESOURCE](
	[ID] [numeric](18, 0) NOT NULL,
	[RESOURCE_TYPE] [varchar](20) NOT NULL,
	[VALUE] [varchar](255) NULL,
	[ORDER_NUM] [numeric](4, 0) NULL,
	[PARENT_ID] [numeric](18, 0) NULL,
	[TARGET] [varchar](20) NULL,
	[ZH_CN_NAME] [varchar](200) NULL,
	[STATUS] [numeric](1, 0) NOT NULL DEFAULT ((1)),
	[LAVELS] [numeric](1, 0) NULL DEFAULT ((0)),
	[REMARK] [varchar](400) NULL,
	[IMG_URL] [varchar](50) NULL,
	[TOTAL_SQL] [varchar](4000) NULL,
	[NAV_IMG_URL] [varchar](200) NULL,
	[NAV_ENABLED] [numeric](1, 0) NOT NULL DEFAULT ((0)),
	[OLD_TOTAL_SQL] [varchar](4000) NULL,
	[ZH_TW_NAME] [varchar](200) NULL,
	[EN_US_NAME] [varchar](200) NULL,
	[FLAG_LAN] [char](2) NULL DEFAULT ('01'),
	[STMS_MENU_ID] [numeric](38, 0) NULL,
	[CLASS_NAME] [varchar](50) NULL,
 CONSTRAINT [PRI_SYS_RESOURCE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_RESOURCE_AUTHORITIE]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_RESOURCE_AUTHORITIE](
	[AUTHORITY_ID] [numeric](9, 0) NOT NULL,
	[RESOURCE_ID] [numeric](9, 0) NOT NULL,
 CONSTRAINT [PK_SYS_RESOURCE_AUTHORITIE] PRIMARY KEY CLUSTERED 
(
	[AUTHORITY_ID] ASC,
	[RESOURCE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SYS_RESOURCE_URL]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_RESOURCE_URL](
	[RESOURCE_ID] [numeric](18, 0) NOT NULL,
	[URL_ID] [numeric](18, 0) NOT NULL,
	[ID] [numeric](18, 0) NOT NULL,
	[TYPE] [numeric](1, 0) NOT NULL DEFAULT ((0)),
 CONSTRAINT [PRI_SYS_RESOURCE_URL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SYS_ROLE]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_ROLE](
	[ID] [numeric](3, 0) NOT NULL,
	[NAME] [varchar](120) NULL,
	[PARENT_ID] [numeric](3, 0) NULL,
	[DESCRIPTION] [varchar](200) NULL,
	[STATE] [numeric](1, 0) NOT NULL DEFAULT ((1)),
	[TYPE] [numeric](1, 0) NOT NULL DEFAULT ((1)),
	[MANAGE_ROLES] [varchar](400) NULL,
	[CLASS_NAME] [varchar](400) NULL DEFAULT ('reg_peo'),
 CONSTRAINT [SYS_ROLE_PRI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_ROLE_ADMIN]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_ROLE_ADMIN](
	[ADMIN_ROLE_ID] [numeric](3, 0) NOT NULL,
	[ROLE_ID] [numeric](3, 0) NOT NULL,
 CONSTRAINT [PK_SYS_ROLE_ADMIN] PRIMARY KEY CLUSTERED 
(
	[ROLE_ID] ASC,
	[ADMIN_ROLE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SYS_ROLE_AUTHORITIE]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_ROLE_AUTHORITIE](
	[ROLE_ID] [numeric](3, 0) NOT NULL,
	[AUTHORITY_ID] [numeric](8, 0) NOT NULL,
	[TYPE] [numeric](1, 0) NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_SYS_ROLE_AUTHORITIE] PRIMARY KEY CLUSTERED 
(
	[ROLE_ID] ASC,
	[AUTHORITY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SYS_ROLE_AUTHORITIE_PLATFORM]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_ROLE_AUTHORITIE_PLATFORM](
	[ROLE_ID] [numeric](3, 0) NOT NULL,
	[AUTHORITY_ID] [numeric](8, 0) NOT NULL,
	[TYPE] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_SYS_ROLE_AUTHORITIE_PLAT] PRIMARY KEY CLUSTERED 
(
	[ROLE_ID] ASC,
	[AUTHORITY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SYS_ROLE_PSN_AUTHORITIE]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_ROLE_PSN_AUTHORITIE](
	[ID] [numeric](18, 0) NOT NULL,
	[USER_ID] [numeric](18, 0) NOT NULL,
	[ROLE_ID] [numeric](3, 0) NOT NULL,
	[AUTHORITY_ID] [numeric](18, 0) NULL,
	[RESOURCE_ID] [numeric](18, 0) NULL,
 CONSTRAINT [SYS_ROLE_PSN_AUTHORITIE_PRI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SYS_USER]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_USER](
	[ID] [numeric](18, 0) NOT NULL,
	[LOGIN_NAME] [varchar](400) NULL,
	[PASSWORD] [varchar](300) NOT NULL,
	[ENABLED] [numeric](1, 0) NOT NULL DEFAULT ((1)),
	[TOKEN_CHANGED] [numeric](1, 0) NULL DEFAULT ((0)),
	[NODE_ID] [numeric](2, 0) NOT NULL DEFAULT ((1)),
	[EMAIL] [varchar](400) NULL,
	[MOBILE] [numeric](30, 0) NULL,
	[UKEYSN] [varchar](80) NULL,
	[UKEYPWD] [varchar](128) NULL,
	[ISUKEY] [char](1) NULL,
	[ISINTERNAL] [char](1) NULL,
	[PLAIN_PWD] [varchar](128) NULL,
	[ADD_USER_ID] [numeric](18, 0) NULL,
	[AUTH_LOGIN_IP] [varchar](200) NULL,
	[LAST_ACCESS_IP] [varchar](100) NULL,
	[LOCALE] [varchar](10) NULL,
	[PASSWORD_UPDATE_TIME] [date] NULL,
	[LAST_LOGIN_TIME] [datetime] NULL,
	[CACHE_VERSION] [int] NULL DEFAULT ((0)),
 CONSTRAINT [PK_USER_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [SYS_USER_UNI_LOGIN] UNIQUE NONCLUSTERED 
(
	[LOGIN_NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_USER_HISTORY]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SYS_USER_HISTORY](
	[AUTO_ID] [numeric](18, 0) NOT NULL,
	[ID] [numeric](18, 0) NOT NULL,
	[LOGIN_NAME] [varchar](400) NULL,
	[PASSWORD] [varchar](300) NOT NULL,
	[ENABLED] [numeric](1, 0) NOT NULL CONSTRAINT [DF__SYS_USER_HISTORY__ENABLE__7211DF33]  DEFAULT ((1)),
	[TOKEN_CHANGED] [numeric](1, 0) NULL CONSTRAINT [DF__SYS_USER_HISTORY__TOKEN___7306036C]  DEFAULT ((0)),
	[NODE_ID] [numeric](2, 0) NOT NULL CONSTRAINT [DF__SYS_USER_HISTORY__NODE_I__73FA27A5]  DEFAULT ((1)),
	[EMAIL] [varchar](400) NULL,
	[MOBILE] [numeric](30, 0) NULL,
	[UKEYSN] [varchar](80) NULL,
	[UKEYPWD] [varchar](128) NULL,
	[ISUKEY] [char](1) NULL,
	[ISINTERNAL] [char](1) NULL,
	[PLAIN_PWD] [varchar](128) NULL,
	[ADD_USER_ID] [numeric](18, 0) NULL,
	[AUTH_LOGIN_IP] [varchar](200) NULL,
	[LAST_ACCESS_IP] [varchar](100) NULL,
	[LOCALE] [varchar](10) NULL,
	[PASSWORD_UPDATE_TIME] [date] NULL,
	[LAST_LOGIN_TIME] [datetime] NULL,
	[CACHE_VERSION] [int] NULL CONSTRAINT [DF__SYS_USER_HISTORY__CACHE___5B86ACF2]  DEFAULT ((0)),
 CONSTRAINT [PK_SYS_USER_HISTORY_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [PK_SYS_USER_HISTORY_AUTO_ID] UNIQUE NONCLUSTERED 
(
	[AUTO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [SYS_USER_HISTORY_UNI_LOGIN] UNIQUE NONCLUSTERED 
(
	[LOGIN_NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SYS_USER_ROLE]    Script Date: 2018/06/12 17:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_USER_ROLE](
	[USER_ID] [numeric](18, 0) NOT NULL,
	[ROLE_ID] [numeric](3, 0) NOT NULL,
	[INS_ID] [numeric](9, 0) NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_SYS_USER_ROLE] PRIMARY KEY CLUSTERED 
(
	[USER_ID] ASC,
	[ROLE_ID] ASC,
	[INS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SYS_ROLE_AUTHORITIE_PLATFORM] ADD  DEFAULT ((0)) FOR [TYPE]
GO
ALTER TABLE [dbo].[SYS_RESOURCE]  WITH NOCHECK ADD  CONSTRAINT [SYS_RESOURCE_TYPE] CHECK  (([RESOURCE_TYPE]='operate' OR [RESOURCE_TYPE]='menu' OR [RESOURCE_TYPE]='url'))
GO
ALTER TABLE [dbo].[SYS_RESOURCE] CHECK CONSTRAINT [SYS_RESOURCE_TYPE]
GO
ALTER TABLE [dbo].[SYS_USER]  WITH NOCHECK ADD  CONSTRAINT [SYS_USER_CHK] CHECK  (([ENABLED]=(1) OR [ENABLED]=(0)))
GO
ALTER TABLE [dbo].[SYS_USER] CHECK CONSTRAINT [SYS_USER_CHK]
GO
ALTER TABLE [dbo].[SYS_USER_HISTORY]  WITH NOCHECK ADD  CONSTRAINT [SYS_USER_HISTORY_CHK] CHECK  (([ENABLED]=(1) OR [ENABLED]=(0)))
GO
ALTER TABLE [dbo].[SYS_USER_HISTORY] CHECK CONSTRAINT [SYS_USER_HISTORY_CHK]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动序列' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_AUTHORITIE.ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限代码名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_AUTHORITIE."NAME"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'DISPLAY_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_AUTHORITIE.DISPLAY_NAME' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'DISPLAY_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' 上级id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'PARENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_AUTHORITIE.PARENT_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'PARENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'权限表:存储每个功能点的描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限表:存储每个功能点的描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_AUTHORITIE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_AUTHORITIE.PRI_AUTHORITIES' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_AUTHORITIE', @level2type=N'CONSTRAINT',@level2name=N'PRI_AUTHORITIES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LOG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG.LOG_CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LOG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'PSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG.PSN_CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'PSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务日志类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LOG_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG.LOG_TYPE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LOG_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'KEY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG.KEY_CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'KEY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'CREATE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG.CREATE_DATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'CREATE_DATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能操作' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LOG_ACTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG.LOG_ACTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LOG_ACTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志明细' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LOG_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG.LOG_DETAIL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LOG_DETAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作客户IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'CLIENT_IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG.CLIENT_IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'CLIENT_IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'SERVER_IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG.SERVER_IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'SERVER_IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'异常日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'EXCEPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG."EXCEPTION"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'EXCEPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户浏览器user_agent' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'USER_AGENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG.USER_AGENT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'USER_AGENT'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'系统日志表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统日志表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_LOG.PK_SYS_LOG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'CONSTRAINT',@level2name=N'PK_SYS_LOG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ORG.ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'ORG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ORG.ORG_CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'ORG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'SYS_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ORG.SYS_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'SYS_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态，0：待审核，1：同意，2：退回，3：拒绝，4：禁用，5：启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'STATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ORG.STATUS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'STATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请人的code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'REQUEST_PSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ORG.REQUEST_PSN_CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'REQUEST_PSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'申请时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'REQUEST_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ORG.REQUEST_TIME' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'REQUEST_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'确认人的code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'CONFIRM_PSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ORG.CONFIRM_PSN_CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'CONFIRM_PSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'确认时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'CONFIRM_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ORG.CONFIRM_TIME' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'CONFIRM_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在具体资助机构下，此单位的审核状态（可能会并入status）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'INFO_STATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ORG.INFO_STATUS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'COLUMN',@level2name=N'INFO_STATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'单位申请加入平台记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位申请加入平台记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ORG' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ORG.SYS_C0031635' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ORG', @level2type=N'CONSTRAINT',@level2name=N'SYS_C0031635'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色id，对应sys_role表的id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PLATFORM_ROLE', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PLATFORM_ROLE.ROLE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PLATFORM_ROLE', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PLATFORM_ROLE', @level2type=N'COLUMN',@level2name=N'PLATFORM_ROLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PLATFORM_ROLE.PLATFORM_ROLE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PLATFORM_ROLE', @level2type=N'COLUMN',@level2name=N'PLATFORM_ROLE'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'平台角色对应关系表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PLATFORM_ROLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台角色对应关系表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PLATFORM_ROLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PLATFORM_ROLE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PLATFORM_ROLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_INFO.ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应资助机构表（sys_info）的主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'SYS_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_INFO.SYS_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'SYS_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应人员信息表（person）的主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'PSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_INFO.PSN_CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'PSN_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应单位信息表（organization）的主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'ORG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_INFO.ORG_CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'ORG_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应角色信息表（sys_role）的主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_INFO.ROLE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员与单位或自主机构的关系，默认1（1：正常，0：被单位解除关系）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'STATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_INFO.STATUS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'COLUMN',@level2name=N'STATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'人员具体信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员具体信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_INFO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_INFO.PK_SYS_PSN_INFO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'CONSTRAINT',@level2name=N'PK_SYS_PSN_INFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_INFO.UNI_SYS_PSN_INFO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_INFO', @level2type=N'CONSTRAINT',@level2name=N'UNI_SYS_PSN_INFO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'sys_psn_info表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_KEYCODE', @level2type=N'COLUMN',@level2name=N'SYS_PSN_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_KEYCODE.SYS_PSN_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_KEYCODE', @level2type=N'COLUMN',@level2name=N'SYS_PSN_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相对应的key_code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_KEYCODE', @level2type=N'COLUMN',@level2name=N'KEY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_KEYCODE.KEY_CODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_KEYCODE', @level2type=N'COLUMN',@level2name=N'KEY_CODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'声明是申报书，合同书等 ：1,申报书,key_code为pos_code；2,项目key_code为prj_code；3,合同书key_code为ctr_code,4,进展报告，5结题报告，6变更，99评审' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_KEYCODE', @level2type=N'COLUMN',@level2name=N'TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_KEYCODE."TYPE"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_KEYCODE', @level2type=N'COLUMN',@level2name=N'TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'SYS_PSN_INFO表与proposal_cached两表关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_KEYCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SYS_PSN_INFO表与proposal_cached两表关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_KEYCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_KEYCODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_KEYCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_PSN_KEYCODE.PK_SYS_PSN_KEYCODE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PSN_KEYCODE', @level2type=N'CONSTRAINT',@level2name=N'PK_SYS_PSN_KEYCODE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单、还是页面menu、url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'RESOURCE_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.RESOURCE_TYPE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'RESOURCE_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'VALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE."VALUE"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'VALUE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顺序(权限控制按顺序匹配URL)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'ORDER_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.ORDER_NUM' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'ORDER_NUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'PARENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.PARENT_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'PARENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示窗名称(''mainFrame'' , ''_blank'',''_parent'')' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'TARGET'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.TARGET' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'TARGET'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名，简体中文' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'ZH_CN_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.ZH_CN_NAME' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'ZH_CN_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'STATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.STATUS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'STATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'层次，用于菜单等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'LAVELS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.LAVELS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'LAVELS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'REMARK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.REMARK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'REMARK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快捷菜单图片的url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'IMG_URL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.IMG_URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'IMG_URL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快捷菜单图片上的统计数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'TOTAL_SQL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.TOTAL_SQL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'TOTAL_SQL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.NAV_IMG_URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'NAV_IMG_URL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.NAV_ENABLED' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'NAV_ENABLED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快捷菜单图片上的统计数(查询老系统)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'OLD_TOTAL_SQL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.OLD_TOTAL_SQL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'OLD_TOTAL_SQL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名，中文繁体' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'ZH_TW_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.ZH_TW_NAME' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'ZH_TW_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名，英文' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'EN_US_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.EN_US_NAME' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'EN_US_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内网标示 (01：外网，10：内网，11：内外网)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'FLAG_LAN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.FLAG_LAN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'FLAG_LAN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联stms系统sys_menu.menu_id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'STMS_MENU_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.STMS_MENU_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'STMS_MENU_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快捷通道的class名字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'CLASS_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.CLASS_NAME' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'COLUMN',@level2name=N'CLASS_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'web资源表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'web资源表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.PRI_SYS_RESOURCE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'CONSTRAINT',@level2name=N'PRI_SYS_RESOURCE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE.SYS_RESOURCE_TYPE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE', @level2type=N'CONSTRAINT',@level2name=N'SYS_RESOURCE_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE_AUTHORITIE.AUTHORITY_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'AUTHORITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE_AUTHORITIE.RESOURCE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'RESOURCE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'资源功能集关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资源功能集关联表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE_AUTHORITIE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE_AUTHORITIE.PK_SYS_RESOURCE_AUTHORITIE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_AUTHORITIE', @level2type=N'CONSTRAINT',@level2name=N'PK_SYS_RESOURCE_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL', @level2type=N'COLUMN',@level2name=N'RESOURCE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE_URL.RESOURCE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL', @level2type=N'COLUMN',@level2name=N'RESOURCE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单下URL编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL', @level2type=N'COLUMN',@level2name=N'URL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE_URL.URL_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL', @level2type=N'COLUMN',@level2name=N'URL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE_URL.ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用来标识该URL是否是菜单value截取而来。1/是， 0/否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL', @level2type=N'COLUMN',@level2name=N'TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE_URL."TYPE"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL', @level2type=N'COLUMN',@level2name=N'TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'菜单极其下面所包含URL的 关系表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单极其下面所包含URL的 关系表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE_URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_RESOURCE_URL.PRI_SYS_RESOURCE_URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RESOURCE_URL', @level2type=N'CONSTRAINT',@level2name=N'PRI_SYS_RESOURCE_URL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE.ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE."NAME"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父角色标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'PARENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE.PARENT_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'PARENT_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简要描述角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'DESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE.DESCRIPTION' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'DESCRIPTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述角色状态：0无效  1有效' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE.STATE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'STATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色类型 , 1授予 ，2下发 ，3授予下发' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE."TYPE"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理的角色，角色ID之间以逗号分隔' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'MANAGE_ROLES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE.MANAGE_ROLES' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'MANAGE_ROLES'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色样式图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'CLASS_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE.CLASS_NAME' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'COLUMN',@level2name=N'CLASS_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N' 角色数据表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' 角色数据表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE.SYS_ROLE_PRI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE', @level2type=N'CONSTRAINT',@level2name=N'SYS_ROLE_PRI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员的角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_ADMIN', @level2type=N'COLUMN',@level2name=N'ADMIN_ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_ADMIN.ADMIN_ROLE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_ADMIN', @level2type=N'COLUMN',@level2name=N'ADMIN_ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'被管理的角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_ADMIN', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_ADMIN.ROLE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_ADMIN', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'角色管理表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_ADMIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色管理表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_ADMIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_ADMIN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_ADMIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_ADMIN.PK_SYS_ROLE_ADMIN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_ADMIN', @level2type=N'CONSTRAINT',@level2name=N'PK_SYS_ROLE_ADMIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_AUTHORITIE.ROLE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资源集ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'AUTHORITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_AUTHORITIE.AUTHORITY_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'AUTHORITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_AUTHORITIE."TYPE"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'角色权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_AUTHORITIE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_AUTHORITIE.PK_SYS_ROLE_AUTHORITIE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE', @level2type=N'CONSTRAINT',@level2name=N'PK_SYS_ROLE_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE_PLATFORM', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_AUTHORITIE_PLATFORM.ROLE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE_PLATFORM', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资源集ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE_PLATFORM', @level2type=N'COLUMN',@level2name=N'AUTHORITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_AUTHORITIE_PLATFORM.AUTHORITY_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE_PLATFORM', @level2type=N'COLUMN',@level2name=N'AUTHORITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_AUTHORITIE_PLATFORM."TYPE"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE_PLATFORM', @level2type=N'COLUMN',@level2name=N'TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'平台需要单独使用的角色权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE_PLATFORM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台需要单独使用的角色权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE_PLATFORM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_AUTHORITIE_PLATFORM' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE_PLATFORM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_AUTHORITIE_PLATFORM.PK_SYS_ROLE_AUTHORITIE_PLAT' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_AUTHORITIE_PLATFORM', @level2type=N'CONSTRAINT',@level2name=N'PK_SYS_ROLE_AUTHORITIE_PLAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_PSN_AUTHORITIE.ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_PSN_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_PSN_AUTHORITIE.USER_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_PSN_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_PSN_AUTHORITIE.ROLE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_PSN_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_PSN_AUTHORITIE.AUTHORITY_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_PSN_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'AUTHORITY_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_PSN_AUTHORITIE.RESOURCE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_PSN_AUTHORITIE', @level2type=N'COLUMN',@level2name=N'RESOURCE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_PSN_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_PSN_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_PSN_AUTHORITIE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_PSN_AUTHORITIE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_ROLE_PSN_AUTHORITIE.SYS_ROLE_PSN_AUTHORITIE_PRI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ROLE_PSN_AUTHORITIE', @level2type=N'CONSTRAINT',@level2name=N'SYS_ROLE_PSN_AUTHORITIE_PRI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键字，同psn_code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'LOGIN_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.LOGIN_NAME' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'LOGIN_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'PASSWORD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.PASSWORD' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'PASSWORD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐号状态 0 禁用,1正常,2-删除用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ENABLED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.ENABLED' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ENABLED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标记是否已确认忘记密码邮件 0-未做忘记密码操作 1-未确认邮件  2-已确认邮件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'TOKEN_CHANGED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.TOKEN_CHANGED' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'TOKEN_CHANGED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户数据存储区域位置（未使用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'NODE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.NODE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'NODE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'首选通信邮件地址(默认同登录名)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'EMAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.EMAIL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'EMAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号码登录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'MOBILE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.MOBILE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'MOBILE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ukey序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'UKEYSN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.UKEYSN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'UKEYSN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ukey的pin密码,与用户表密码一致' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'UKEYPWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.UKEYPWD' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'UKEYPWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否对此用户启用(1启用 ,null 不启用,启用的在外网不能登陆)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ISUKEY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.ISUKEY' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ISUKEY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否基金委内用户(1是 ,0不是，是基金委用户的，不允许在外网登录)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ISINTERNAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.ISNSFC' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ISINTERNAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.PLAIN_PWD' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'PLAIN_PWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邀请专家,添加人id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ADD_USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.ADD_USER_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ADD_USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录的ip范围控制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'AUTH_LOGIN_IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.AUTH_LOGIN_IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'AUTH_LOGIN_IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次登录的ip地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'LAST_ACCESS_IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.LAST_ACCESS_IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'LAST_ACCESS_IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'LAST_LOGIN_TIME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户缓存版本,当SA修改具体PC的权限的时候,此值会改变' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'CACHE_VERSION'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'能够登录的 人员信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'能够登录的 人员信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.PK_USER_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'CONSTRAINT',@level2name=N'PK_USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.SYS_USER_UNI_LOGIN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'CONSTRAINT',@level2name=N'SYS_USER_UNI_LOGIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER.SYS_USER_CHK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'CONSTRAINT',@level2name=N'SYS_USER_CHK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键字，同psn_code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'LOGIN_NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'PASSWORD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐号状态 0 禁用,1正常,2-删除用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'ENABLED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标记是否已确认忘记密码邮件 0-未做忘记密码操作 1-未确认邮件  2-已确认邮件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'TOKEN_CHANGED'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户数据存储区域位置（未使用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'NODE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'首选通信邮件地址(默认同登录名)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'EMAIL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号码登录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'MOBILE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ukey序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'UKEYSN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ukey的pin密码,与用户表密码一致' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'UKEYPWD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否对此用户启用(1启用 ,null 不启用,启用的在外网不能登陆)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'ISUKEY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否基金委内用户(1是 ,0不是，是基金委用户的，不允许在外网登录)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'ISINTERNAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邀请专家,添加人id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'ADD_USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录的ip范围控制' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'AUTH_LOGIN_IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次登录的ip地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'LAST_ACCESS_IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户缓存版本,当SA修改具体PC的权限的时候,此值会改变' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY', @level2type=N'COLUMN',@level2name=N'CACHE_VERSION'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'能够登录的 人员信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'能够登录的 人员信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_HISTORY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_ROLE', @level2type=N'COLUMN',@level2name=N'USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER_ROLE.USER_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_ROLE', @level2type=N'COLUMN',@level2name=N'USER_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_ROLE', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER_ROLE.ROLE_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_ROLE', @level2type=N'COLUMN',@level2name=N'ROLE_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_ROLE', @level2type=N'COLUMN',@level2name=N'INS_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER_ROLE.INS_ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_ROLE', @level2type=N'COLUMN',@level2name=N'INS_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'Description', @value=N'用户角色表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_ROLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户角色表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_ROLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER_ROLE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_ROLE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'KJGL_TEST.SYS_USER_ROLE.PK_SYS_USER_ROLE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER_ROLE', @level2type=N'CONSTRAINT',@level2name=N'PK_SYS_USER_ROLE'
GO

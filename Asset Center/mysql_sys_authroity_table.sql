DROP TABLE IF EXISTS SYS_AUTHORITIE;

DROP TABLE IF EXISTS SYS_RESOURCE;

DROP TABLE IF EXISTS SYS_RESOURCE_AUTHORITIE;

DROP TABLE IF EXISTS SYS_ROLE;

DROP TABLE IF EXISTS SYS_ROLE_AUTHORITIE;

DROP TABLE IF EXISTS SYS_USER_ROLE;

DROP TABLE IF EXISTS SYS_USER;

/*==============================================================*/
/* Table: SYS_AUTHORITIE                                        */
/*==============================================================*/
CREATE TABLE SYS_AUTHORITIE
(
   AUTHORITY_ID         NUMERIC(8, 0) NOT NULL  COMMENT '自动序列',
   NAME                 VARCHAR(400)  COMMENT '权限代码名',
   DISPLAY_NAME         VARCHAR(400)  COMMENT '权限描述',
   PARENT_ID            NUMERIC(8, 0) COMMENT ' 上级id',
   PRIMARY KEY (AUTHORITY_ID)
) COMMENT '权限表';

/*==============================================================*/
/* Table: SYS_RESOURCE                                          */
/*==============================================================*/
CREATE TABLE SYS_RESOURCE
(
   RESOURCE_ID          NUMERIC(18, 0) NOT NULL COMMENT '主键',
   RESOURCE_TYPE        VARCHAR(20) NOT NULL COMMENT '菜单、还是页面menu、url',
   VALUE                VARCHAR(255) COMMENT 'URL',
   ORDER_NUM            NUMERIC(4, 0) COMMENT '顺序(权限控制按顺序匹配URL)',
   PARENT_ID            NUMERIC(18, 0) COMMENT '父菜单',
   TARGET               VARCHAR(20) COMMENT '显示窗名称(mainFrame , _blank,_parent)',
   ZH_CN_NAME           VARCHAR(200) COMMENT '菜单名，简体中文',
   STATUS               NUMERIC(1, 0) NOT NULL DEFAULT 1 COMMENT '是否启用状态',
   LAVELS               NUMERIC(1, 0) DEFAULT 0 COMMENT '层次，用于菜单等级',
   REMARK               VARCHAR(400) COMMENT '备注',
   IMG_URL              VARCHAR(50) COMMENT '快捷菜单图片的url',
   TOTAL_SQL            VARCHAR(4000) COMMENT '快捷菜单图片上的统计数',
   NAV_IMG_URL          VARCHAR(200) COMMENT 'Nav 菜单图片的url',
   NAV_ENABLED          NUMERIC(1, 0) NOT NULL DEFAULT 0 COMMENT 'Nav enable',
   OLD_TOTAL_SQL        VARCHAR(4000) COMMENT '快捷菜单图片上的统计数(查询老系统)',
   ZH_TW_NAME           VARCHAR(200) COMMENT '菜单名，中文繁体',
   EN_US_NAME           VARCHAR(200) COMMENT '菜单名，英文',
   FLAG_LAN             CHAR(2) DEFAULT '01' COMMENT '内网标示 (01：外网，10：内网，11：内外网)',
   STMS_MENU_ID         NUMERIC(38, 0) COMMENT '关联stms系统sys_menu.menu_id',
   CLASS_NAME           VARCHAR(50) COMMENT '快捷通道的class名字',
   PRIMARY KEY (RESOURCE_ID)
) COMMENT 'web资源表';

/*==============================================================*/
/* Table: SYS_RESOURCE_AUTHORITIE                               */
/*==============================================================*/
CREATE TABLE SYS_RESOURCE_AUTHORITIE
(
   AUTHORITY_ID         NUMERIC(9, 0) NOT NULL COMMENT '权限表主键',
   RESOURCE_ID          NUMERIC(9, 0) NOT NULL COMMENT '资源表主键',
   PRIMARY KEY (AUTHORITY_ID, RESOURCE_ID)
)COMMENT '资源功能集关联表';

/*==============================================================*/
/* Table: SYS_ROLE                                              */
/*==============================================================*/
CREATE TABLE SYS_ROLE
(
   ROLE_ID              NUMERIC(3, 0) NOT NULL COMMENT '角色标识',
   NAME                 VARCHAR(120) COMMENT '角色名称',
   PARENT_ID            NUMERIC(3, 0) COMMENT '父角色标识',
   DESCRIPTION          VARCHAR(200) COMMENT '简要描述角色',
   STATE                NUMERIC(1, 0) NOT NULL DEFAULT 1 COMMENT '描述角色状态：0无效  1有效',
   TYPE                 NUMERIC(1, 0) NOT NULL DEFAULT 1 COMMENT '角色类型 , 1授予 ，2下发 ，3授予下发',
   MANAGE_ROLES         VARCHAR(400) COMMENT '管理的角色，角色ID之间以逗号分隔',
   CLASS_NAME           VARCHAR(400) DEFAULT 'reg_peo' COMMENT '角色样式图标',
   PRIMARY KEY (ROLE_ID)
)COMMENT '角色数据表';

/*==============================================================*/
/* Table: SYS_ROLE_AUTHORITIE                                   */
/*==============================================================*/
CREATE TABLE SYS_ROLE_AUTHORITIE
(
   ROLE_ID              NUMERIC(3, 0) NOT NULL COMMENT '角色ID',
   AUTHORITY_ID         NUMERIC(8, 0) NOT NULL COMMENT '资源集ID',
   TYPE                 NUMERIC(1, 0) NOT NULL DEFAULT 0 COMMENT '类型',
   PRIMARY KEY (ROLE_ID, AUTHORITY_ID)
)COMMENT '角色权限表';

/*==============================================================*/
/* Table: SYS_USER_ROLE                                         */
/*==============================================================*/
CREATE TABLE SYS_USER_ROLE
(
   USER_ID              NUMERIC(18, 0) NOT NULL COMMENT '用户ID',
   ROLE_ID              NUMERIC(3, 0) NOT NULL COMMENT '角色ID',
   INS_ID               NUMERIC(9, 0) NOT NULL DEFAULT 0 COMMENT '单位ID',
   PRIMARY KEY (USER_ID, ROLE_ID, INS_ID)
)COMMENT '用户角色表';


/*==============================================================*/
/* Table: SYS_USER                                              */
/*==============================================================*/
CREATE TABLE SYS_USER
(
   USERID               NUMERIC(18, 0) NOT NULL COMMENT '关键字，同psn_code',
   LOGIN_NAME           VARCHAR(400) NOT NULL COMMENT '登录名',
   PASSWORD             VARCHAR(300) NOT NULL COMMENT '密码',
   ENABLED              NUMERIC(1, 0) NOT NULL DEFAULT 1 COMMENT '帐号状态 0 禁用,1正常,2-删除用户',
   TOKEN_CHANGED        NUMERIC(1, 0) DEFAULT 0 COMMENT '标记是否已确认忘记密码邮件 0-未做忘记密码操作 1-未确认邮件  2-已确认邮件',
   NODE_ID              NUMERIC(2, 0) NOT NULL DEFAULT 1 COMMENT '用户数据存储区域位置（未使用）',
   EMAIL                VARCHAR(400) COMMENT '首选通信邮件地址(默认同登录名)',
   MOBILE               NUMERIC(30, 0) COMMENT '手机号码登录',
   UKEYSN               VARCHAR(80) COMMENT 'ukey序列号',
   UKEYPWD              VARCHAR(128) COMMENT 'ukey的pin密码,与用户表密码一致',
   ISUKEY               CHAR(1) COMMENT '是否对此用户启用(1启用 ,null 不启用,启用的在外网不能登陆)',
   ISINTERNAL           CHAR(1) COMMENT '是否基金委内用户(1是 ,0不是，是基金委用户的，不允许在外网登录)',
   PLAIN_PWD            VARCHAR(128) COMMENT '不知道',
   ADD_USER_ID          NUMERIC(18, 0) COMMENT '邀请专家,添加人id',
   AUTH_LOGIN_IP        VARCHAR(200) COMMENT '登录的ip范围控制',
   LAST_ACCESS_IP       VARCHAR(100) COMMENT '最后一次登录的ip地址',
   LOCALE               VARCHAR(10) COMMENT '不知道',
   PASSWORD_UPDATE_TIME DATE COMMENT '密码更新时间',
   LAST_LOGIN_TIME      DATETIME COMMENT '最后登录时间',
   PRIMARY KEY (USERID)
)COMMENT '能够登录的 人员信息表';



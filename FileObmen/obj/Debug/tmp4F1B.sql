ALTER TABLE [dbo].[Files] ADD [Password] [nvarchar](max)
ALTER TABLE [dbo].[Files] ADD [DeleteTime] [datetime] NOT NULL DEFAULT '1900-01-01T00:00:00.000'
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201601261116245_Migration1', 0x1F8B0800000000000400DD59CD6EE33610BE17E83B083AB505D64AB27BD806CE2E52272E16DDFC20CAEE35A0A5B14394225592CE3A7DB51EFA487D850EF54B8992ADD88991F612C824E79B21F9CD0C67F2CF5F7F8F3FAE12E63D805454F013FF7074E07BC0231153BE38F1977AFEE6BDFFF1C3F7DF8DCFE364E57D2DD7BD35EB5092AB13FF5EEBF4380854740F0951A38446522831D7A34824018945707470F0737078180042F888E579E39B25D73481EC07FE9C081E41AA97845D8818982AC67126CC50BD4B92804A490427FE9432B89A25C047F95ADF3B6594A01D21B0B9EFA5EF8EBF2808B5147C11A64453C26E1F53C0F939610A0AAB8FD377430D3F383286078473A1114EF0AD36EE575BC24D9DE3E6F5A3312BDBD8898F164B7B05AEF90D1E1B0338742D450A523FDEC0BC90FB14FB5ED0940BDA829598256354E317D76F8F7CEF72C9189931A84E088F30D442C2AFC041120DF135D11A2437B29099EE686DE9385DC02625EB013E8B05E525045E26B2D1F7A67405F167E00B7D5FC15C905539829FBEF78553242F0A69B9045B6DFE7BBDD6F38450B677ADD744A96F42C67B577C030BAAB4CC487D86F75C1A60BE6FD13B37DFDA2579A08B4CBE056D9C143DF3065836ABEE699A3BE8C8CCDC657CF7A65224378215CBB3C1BB5B2217A0D112D19E09C552462D13C641ED4A6B1DCCC0FC9F1C2CA47FEEE861E6EFDE1967D4ED5DA961CF9A3B79D52E7A062A9234CDD3CE9E754F2464CE9B8782A7860667230C4AD1678B327918797A902943891B64CAF03324C89C2A25229AA9B6A2CC5D472E3FE7B1D76B437EA9A5D578874BA669CA68842A4FFC9F9CD3E802ABA2660D96EFBE0976301A1D3A7818EC409AA843183EC34C3EA05CBB9191F288A684F5A96E090C0CA6E6702BE8F6CC19A4C04D3CEC3BBB213A4BE777F556F0ADF0BEE93CC68175F16ED241198D12202D4E64CF5533012BED50C30885A02D7B3171D68C6B5CA74385A67091751DE19C582D616B174D84C271AC79C7ABDA87B98EE09591957DCE5DACA3B4255E9C4D3B1F3737D2E1B8D595D4654590D71565FD11F41420E30B92A6186DAD82A418F1C2BC1A99BC099F5E0F24394610A98EB2A0B2B6D2844F05B280D62CAA464BA7542A8D9194CC88099C933871960D2560A9CEE6A17B5125B3CAD5E6BB45F4A22E1B7531A53EC029EE2931CE9DBD845AB7EC8A65A5206144763CB626822D13DE1F63FAA5B33AC516CF0686CB17658A8D500C0DC7288A0E1BA3181A8E51BF4F6C987A7438925B13D888EEAC8B3C0E5A37EC445E87452D876E53721061F3D8B21361DD2221C3D844D86EB197216CFEEEB7E5F391E108F9BBDF46C8478623E48F781B211F198E5026651BA32F51F7A33C1FE91BAF6C1BAC31311CAFF972B6019B334FB1B07E3E370DACC7F7EC8A4E766D2FA9B45759B6954DC74566DBDCF373525DBEC4F7F0981E686CD25CF8A8342423B36014FEC1268CE27EEB051784D339287D2B7E077CCF60267EDF6A1C6ED1D40B948AD96BECEC51B3F58D2D8627967056532FC3DFA5A5C71F888CEE89FC2121AB1F776AD3ED84D4AEEB7702EB6BA7C5F8AD3717BAAFBC97F52294B2DB58DB70CA6E62ED747776636A27A066B3A9B5A7BD53B2A37DB4135E574B6820BD87B48476F4946D1A3279ADBB4DDFA459B46ED1C8D9AAF1D25354BD48B3E5BFD16071CBE0CD1D96DE064BFEAE4026CE04DE68CEC0EEB64357EFA5B7F5D205DBD90C79A1AE8CBDE7BAC8DED488717A372FD37B715F81C811EBFFC3C84D45173584F96F3187A8C18E6ACD273E1725495B16954B5A61E80234C1C0434EA5A67312699C8E40A9ACC7FE95B065F6E09841FC895F2D75BAD4B8654866ACF12F1A43F675FAB30653D3E6F1551696D5736C01CDA426765EF15F9694C595DDD38ED8D90361BCA848ECE62ECD3306168F15D2A5E003818AE3AB9CFF1692942198BAE22179807EDB369F61F3C4C667942C2449548151CBE34FA45F9CAC3EFC0BB6E59D98E1200000, '5.0.0.net45')
ALTER TABLE [dbo].[Files] ADD [Sha] [nvarchar](max)
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201601261555593_Migration2', 0x1F8B0800000000000400DD59CD6EE33610BE17E83B083AB505D64AB27BD806CE2ED2FC148B6E7E1065F71AD0D2D8264A912A49679DBE5A0F7DA4BE4287FAA544C996EDC4487B096492F3CD909C19CE7CF9E7AFBFC71F9709F31E412A2AF8897F383AF03DE09188299F9DF80B3D7DF3DEFFF8E1FBEFC61771B2F4BE96EBDE9A7528C9D5893FD73A3D0E0215CD21216A94D0480A25A67A14892420B1088E0E0E7E0E0E0F0340081FB13C6F7CB7E09A2690FDC09F67824790EA0561572206A68A719C093354EF9A24A05212C1897F4919DC4C12E0A37CADEF9D324AD08E10D8D4F7D277C75F14845A0A3E0B53A22961F74F29E0FC94300585D5C7E9BBA1861F1C19C303C2B9D00827F8561BF7AB2DE1A62E70F3FAC998956DECC4478BA5BD02D7FC064F8D011CBA952205A99FEE605AC87D8A7D2F68CA056DC14ACC9231AAF18BEBB747BE77BD608C4C1854278447186A21E157E0208986F896680D921B59C84C77B4B6749CCE609D92D5009FC58CF212022F13BDD1F72EE912E2CFC0677A5EC15C916539829FBEF78553745E14D27201B6DAFCF76AAD1709A16CEF5A6F8952DF848CF7AEF80E6654699939F539DE736980F9BEC7E85C7F6BD7E491CE32F916B409528CCC3B60D9AC9AD3340FD0919979C8FCDDBB9422B913AC589E0D3EDC1339038D9688F64C2816326A99300EEA505A196006E6FF146021FD73C7080BE764EF0E67FEEE5DA951B777A5C66357F8C1AB4E0BE7A02249D3FCA9DBB3EE330959C2C8D3CFA6E9C8D9088352F4D9325B9EBA364F6C65FA72135B99F28624B653A5444433D556667BE8A81F2E78ECF5DA905F6A6935DEE182699A321AA1CA13FF27E734BAC0AA4C5D83E5BB6F821D8C46870E1E26589026D31186A59F798328D76E36A63CA229617DAA5B020313B839DC0ABA3D730E29709383FBCE6E88CE32F85DBD157CEB4959771EE3C0BA78F7A143198D12202D9FC84A6433014BEDB886110A415BF6E2635D7B5CE33A1D57680A172FBD239C3B564BD8DA4513A1081C6BDE89AAF661AE72F0CAC8CA3EE72E56B9B4255E9C4DBB06686EA42370AB2BA95B9920EF65CA9E27E8697AC657244D31DB5A4D5031E285790774F626DCBC0749728C20521DAD48656DA509CB133283D62CAA464B2FA9541A332999109338CFE2C45936D4014B75B61FBA17557A56B9DA7CB71CBDE805475D9E521FE025EE2931C19D555FAD5B76C5B2F69330223B0ABC33C11609EFCF31FDD2596F648B6703C3E58BD6C84628868663148D8E8D510C0DC7A8EB131BA61E1D8EE4F62136A23BEB228F83D60D3B99D7F1A25640B75D7290C3E6B9652787751B930C639DC3768BBD8CC3E6BD862D9F8F6C80607A8D068019182E9FF70D36403E321C216F026C847C643842F9A8DB187D0F7D3FCAF3054DA34AB7C11A13C3F19A95B70DD89CD9C4C2BAFC6E1A588FEF39949DD7B9BDA4D25EBDD2ADD7785CBC8CEB794AE7A9CC97F81E1ED3238DCD33193E290DC9C82C18857FB0334671BFF5822BC2E91494BE17BF03D643F892BF6F919D5B10918152317B8D6C24355B5F4B8B6CD8025A446486BF0B0DC91F898CE644FE9090E58F3B518B3B21B579819DC0FA28C018BFF5FA46F995F36F2FE25236F5B68D4F59C4DB4E576793693B01D904D94E404DD2AB75367B77ED0E1A6B27BC2E6A6A60980CA1A6768CB86D88A1BCE7DE86BF6936CF5B104A5B11403DCDDD8B903EFF0DA2C76DC7D7333DBD444F5E9FA0274E04DE68EE81DDF4471707D44B0175C17692322FC40ED97BAE9BFD758490C321BD0C07E45693E823D6FFC6D137159DD510E63FE51CA28677546B3EF1A9289DB46551B9A49586AE40134C3CE4546A3A2591C6E90894CAB8FEAF842DB2C26502F1277EB3D0E942E3962199B0C6BFA78CB3AFD29F115D4D9BC737595A56CFB10534939ADC79C37F59501657765F76E4CE1E081345458160EED29443307BAA90AE051F08541C5F15FCF790A40CC1D40D0FC923F4DBB6FE0C9B27363EA7642649A20A8C5A1E7FA2FBC5C9F2C3BFE907CC73DD210000, '5.0.0.net45')
CREATE TABLE [dbo].[Roles] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max),
    CONSTRAINT [PK_dbo.Roles] PRIMARY KEY ([Id])
)
ALTER TABLE [dbo].[Users] ADD [RoleId] [int]
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
CREATE INDEX [IX_RoleId] ON [dbo].[Users]([RoleId])
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201604261833339_Role', 0x1F8B0800000000000400DD5A4B6FDC3610BE17E87F10746A0B64653B39A4C63A81EB4711347EC07272356869764D94225592EBECF6AFF5D09FD4BF5052D48312A595F659D717432639DF0C87C399E1CCFEF3D7DFE38FF38478CFC00566F4C43F1C1DF81ED088C5984E4FFC999CBC79EF7FFCF0FD77E38B38997B5F8B756FF53A4549C589FF24657A1C04227A820489518223CE049BC851C49200C52C383A38F839383C0C4041F80ACBF3C677332A7102D93FEADF33462348E50C912B160311F9B89A093354EF1A25205214C1897F8909DC3C26404766EDE80E5226B0647CE17BA7042325520864E27BE9BBE32F0242C9199D8629921891FB450A6A7E8288807C03C7E9BBA17B3838D27B0810A54C2A3846D7D2815FEE4EEDEF42E9412EB458D91E4F7C2531B757A835BFC1A236A0866E394B81CBC51D4C72BA4FB1EF0575BAA049589259349AB5FAA2F2ED91EF5DCF08418F044A0D2915864AB3F02B50E048427C8BA4044E352D64A23B5C1B3C4EA7D0C76439C01D23B04450C967BD109FD914D30241D983B26DDFBBC473883F039DCAA752922B342F46D4A7EF7DA1585D8592CB6A5C2F1284C9DEB9DE2221BE311EEF9DF11D4CB1903CBB17E7CA540A01F4F7BDBAEBFD077F8D9EF134A36F3101DFBB03924D8A279C9A2B3ED297E5C1CC5E7296E82F7383B2C18790CD78A40561CD997BC4A720874BA09D8E681541CF3C6497D612A11C2C19152254338570B608E3A0F2074BBD44B6E757E425F4DF1D5BEC60DDEA237A4DBA0DF19F1BBAE0F009EDDD9DECC1225CA69ADDDE996A6FB06180FBCF9CFE398888E3D4E4427BE67DC62173C626B8AC1A6C9C8D102848B716B74C58583D6834E3961B4E8638B65321588433D6963C0F2DA1E382C65E67EC34875A445B75863322714A70A4589EF83F39DA68032BA3600566A2761DEC60343A74F0948305AE3D1D22EA99A0330C4CA5EB8D318D708A4817EB06C14007AE955B423767CE2105AA7D7097EE86F02CB25B976F09DF08297DFA1807D6C12FB787CA0CBB8EB0C526AB23CC02E50AF6D092152D37AEEDD983C37A0FF6E0E86E08CF2218ECC11E8CD75034525100B76C227B5EEB09984BC734345108D2925725C69507AA1DA7630A7562ADA73662E31B7A88F394DC213656D920B65450973D7F3D58F3CED3A27912CBBC652964A919E72097F9478B3CD74D33A1AC6F64C026AD50E36EB2C301F4B8004BCAFC10966CD2BDF47D3A5AB2C922D495465B158A0253292A2A4A414749697C85D254E5275689291FF142535F3A7B13AE5ED6490C46108996EA4E296DC94925F4680A8D59C55A497A89B9902AF7408F48A71A6771E22C1B7A450B76F64D750FAAB83EC56AFDDD70056EA56DD46634952E2FD5F612ED09B3A74BE3C05DB2ACCE8708E22DAFA333466609ED76C8DDD459E5C926CF0686D317A1D986E80AD7DD2879EDC906C9878663E495241B231F1A8E513D116C986A7405BD38859E9A869C5917791C34ECC409768E59363C44D3C607DD00E352B77503DA62C3801BD04EB69B1B60DED036BD1979312762C2C7B64EC42DDC0C3A9176B2DD9C88A9C5D8F4666405045D8BA901E8815DD84417822992D8086664384291E4DA185D896F37CAF63C5AAD8A6183D52686E3D52B1336607D661509ABF2445DC06A7CCFB7DAC9C59A4B4AEE654ED6C8BDC6791ED4DFF3731223B3C4F7949A9E71AC93A27021242423BD6014FE41CE0856FBAD165C218A2720E43DFB1D54F6ABF2B6F78D6EE11A9DBC408898BCC4761ED65BEF2D1BAF5822B33A7919FE467DBC06C2CA5D3CFA8C78F484F80F099AFFB851676E23A466E17523B0AE0E5AACBE657F25F285378F76629376976005DDBFF05ED04E5465B781D6B9BF561368232B5FF3C896376B3602AA3760D6F04C5BF5022D2D958DF0DADA24033DCA9036C986CE699D268529D9ADD34BA8D7DED6686EAC557CEE7829EEA401F11A9A0E83CEA6E77C4D1578E566C5DACDA67D3514FE1F4D04B790D9DF45E86C22985C5F799A47A64ED47898F6C2715B7FA1B3BDD006DB5E746FEB3C74361EDA605BABE43BEA49D87BAE0A4E7D6D08A72AFF123A0F83046BB9F5CDDACE4EFA0BEEDB55DD22EB57ADEAF60A3CAD20F46F5C2944B5FB53AEF94427ACB8C60D898A258D407C0512A9D08B4EB9C4131449351D8110D92F2FBE2232CB5E398F107FA2373399CEA4DA32248FA4F66321ED0E96F1CF9A287599C737596222B6B1052526D6D9C30DFD6586495CCA7DD9923D7440683F93A7C8FA2CF5DB09A68B12E99AD18140B9FA4AF7780F494A1498B8A1217A866ED9FA7558D7D8F81CA3294789C8312A7AF5AF32BF38997FF8173EFCAEAB972D0000, '5.0.0.net45')
ALTER TABLE [dbo].[Users] ADD [AvatarPath] [nvarchar](max)
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201605011802275_AvatarPath', 0x1F8B0800000000000400DD5ACD6EDC3610BE17E83B083AB505B2B29D1CD2609DC0F54F1134B603CBC9D5A0A5D95DA214A9925C77B7AFD6431FA9AF5052D40F254ABBD2FEC5F5C59049CE37C3E1706638B3FFFEFDCFF8C32221DE137081193DF58F4747BE07346231A6D3537F2E27AFDEFA1FDE7FFFDDF8324E16DED762DD6BBD4E515271EACFA44CDF058188669020314A70C4996013398A5812A098052747473F07C7C70128085F6179DEF86E4E254E20FB47FD7BCE6804A99C2372CD6220221F57336186EADDA004448A2238F5AF3081DBC704E8C8AC1DDD41CA04968C2F7DEF8C60A4440A814C7C2F7DF3EE8B80507246A7618A2446E47E99829A9F202220DFC0BBF44DDF3D1C9DE83D04885226151CA31BE9C02F77A7F677A9F420975AAC6C8FA7BE9298DB2BD49ADF60591B50439F394B81CBE51D4C72BA8FB1EF0575BAA049589259349AB5FAA2F2F589EFDDCC09418F044A0D2915864AB3F02B50E04842FC1949099C6A5AC84477B836789C4D611D93D500778CC00A41259FAF85F8C4A6981608CA1E946DFBDE155E40FC09E854CE4A49AED1A218519FBEF7856275154A2EC3B85E2608938373FD8C84F893F1F8E08CEF608A85E4D9BDB850A65208A0BFEFD55D1F7CF0674F4822AE0C6EB6FFBDDCA0273CCD446FB13EDFBB03924D8A194E8D7719E97BFA6066AF384BF497B9BCD9E043C8E63CD23A60CD997BC4A720FB4BA0FD9D681541CF3C64FEC212A11C2C19152254338570B608E3A072452B1D54B6E717E4A0F4DF3D1B586FDDEA237A49BA0DF15F5B7AFF70860EEEC90E60112E53CDEEE04CB537D832B67EB378730122E2383569D881799F73C89CB1896B5BC6B90B2050900E85EA8C1A262C0C0F1ACDB8E586933E8EED4C0816E18CB525CF434BE8B8A4B1D7193BCDA116D1569DE19C489C121C2996A7FE4F8E36DAC0CA28588199A85D073B1A8D8E1D3CE560816B4F87887AA1E8E40653E97A634C239C22D2C5BA41D0D3816BE596D0CD990B48816A1FDCA5BB3E3C8BC4DAE55BC23742CA3A7D8C03EBE057DB4365865D47D86293D511668172803DB46445AB8D6B77F6E0B03E803D38BAEBC3B3080607B007E335148D5414C02D9BC85EF67A0216D2310D4D1482B4E4558971E5816AC7E998429D58EBA98DD8F88635C4794AEE101BAB6C105B2AA8CB9EBF1EAC79E769D13C8955DEB214B2D48C7390ABFCA3459EEBA69950D637D2639356A87137D9E100D6B8004BCAFC10566CD2BDF4EB74B4629345A82B8DB6AA5105A6485514B3828E6AD6F81AA5A9CA4FACEA563EE285A6B475FE2A1C5E514A0C46108996C252296DC94925F4680A8D59C55A497A85B9902AF7408F48A71AE771E22CEB7B450B76F64D750FAAB83EC56AFDDD70056E916FD46634952EAFD4F612ED09B3A74BE3C05DB2ACC48808E22DAFA37346E609ED76C8DDD459D1CB26CF06FAD317A1D986E80AD7DD2879D9CB06C987FA63E4452C1B231FEA8F513D116C986A74805E9C1A534D43CEEC8013B38A4DB583B3C65DB471D0B03A27743A46DEF037CD1BD3EB3E1907BDABFBD416697ADCA776B2FDDC27F322B7E9CDC8B33911138C7675226E19A8D789B493EDE7444C65C7A6372303107465A706A007F661135D08A6E462239891FE0845CA6C6374A5D1DD28BBF38FB59A880D569BE88F57AF73D880F599211256C58EBA80D5F8816FB593D9359794DCCB0CAF91C98DF3AC6A7DF3D249B3CC12DF536A7AC2B14EB1C2A590908CF48251F807392758EDB75A708D289E8090F7EC7750B9B4CA02DF36DA9E1BB424032162F21CFB92586F7D6D117A6863A96A4966F85B35241B0883DB91F409F16886F80F095AFCB8558B712BA46619772BB0AE5660ACBEE56E5A8103E47BE69DADBD98B8DDC2D887AABE4DA36A2FAAB27B549BB803AB43B5D5A5D9F0C8567792B602AA77873670743B752A2DFD9EADF0DA7A381B3B28B787D3136A971D14534FDCA4D1512F0C6ED079D9A832DEF1F0DC4B77E42574447A9DCD9AF33525EAC19D948D3B6187EA76FC3F3A1C6E95757D8BA3B3C3619E0ECAD33C3275A2C6C3B457B5DB9A1F9DBD8F36D8F68E405B5BA4B32BD206DB5AC2DF53C3C4DE7355BF5AD723715A06CFA12DD24BB0965BDF2C15EDA5F9E13E85D52DB27EEDAB6EAFC0D30A42FFF6974254BB3FE59A8F74C28A6BDC90A858D208C4D720910ABDE88C4B3C419154D3110891FD2CE42B22F3ECD1F408F1477A3B97E95CAA2D43F2486ABF64D2EE6015FFACC35397797C9B252662175B5062629D3DDCD25FE698C4A5DC572DD9430784F633798AACCF523FC560BA2C916E18ED0994ABAF748FF790A44481895B1AA227E8966DBD0EEB1A1B5F6034E52811394645AFFE55E617278BF7FF0158A3FAC7AF2E0000, '5.0.0.net45')
ALTER TABLE [dbo].[Users] ADD [FirstName] [nvarchar](max)
ALTER TABLE [dbo].[Users] ADD [LastName] [nvarchar](max)
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201605031520073_UserName', 0x1F8B0800000000000400DD5A4B73DB3610BE77A6FF81C353DB99887692439A919371FDE864EA47C67472F5C0E44AC21404580072A5FEB51EFA93FA170A107C800429917AD9CD8D02B0DF2E168BDDC5AEFEFDFB9FF1C74542BC27E002337AE21F8F8E7C0F68C4624CA727FE5C4E5EBDF33F7EF8FEBBF1459C2CBCAFC5BA377A9DA2A4E2C49F4999BE0F0211CD20416294E08833C1267214B12440310B5E1F1DFD1C1C1F07A0207C85E579E3BB39953881EC87FA79C66804A99C2372CD6220221F57336186EADDA004448A2238F12F3181DBC704E8C8AC1DDD41CA04968C2F7DEF9460A4440A814C7C2F7DFBFE8B80507246A7618A2446E47E99829A9F202220DFC0FBF46DDF3D1CBDD67B0810A54C2A384637D2815FEE4EEDEF42E9412EB558D91E4F7C2531B757A835BFC1B236A0863E73960297CB3B98E4749F62DF0BEA744193B024B368346BF545E59BD7BE773327043D122835A454182ACDC2AF40812309F167242570AA692113DDE1DAE0713A85754C5603DC31022B04957CBE16E28A4D312D10943D28DBF6BD4BBC80F80AE854CE4A49AED1A218519FBEF7856275154A2EC3B85E622EA4FE3C38E72BF44C8C2F1284C9C1B97E4642FCC9787C70C67730C542F2CC159CABDB5108A0BFEF7102836DFDF40949C4D51D9BED7F2F37E8094F33D15B2E9CEFDD01C926C50CA7C6A18EB46B7A30B3979C25FACBF8AB6CF02164731E691DB0E6CC3DE25390FD25D02E5EB48AA0671E32176989500E968C0A11AA9942385B84715079DF953E39DBF337E4930FE01B7AEB561FD1B7A4DB10FFB565C00B67E8E09EEC59A285667770A6DA1B6C994E3C5BBC390711719C9ACCF3C0BCCF3864CED8C4B52DE3DC39102848874275460D131686078D66DC72C3491FC7762A048B70C6DA92E7A125745CD0D8EB8C9DE6508B68ABCE704E244E098E14CB13FF27471B6D606514ACC04CD4AE831D8D46C70E9E72B0C0B5A743443DCA747283A974BD31A6114E11E962DD20E8E9C0B5724BE8E6CC39A440B50FEED25D1F9EC55BC2E55BC23742CA3A7D8C03EBE057DB4365865D47D86293D511668172803DB46445AB8D6B77F6E0B03E803D38BAEBC3B3080607B007E335148D5414C02D9BC88A197A0216D2310D4D1482B4E4558971E5816AC7E998429D58EBA98DD8F88635C4794AEE101BAB6C105B2AA8CB9EBF1EAC79E769D13C8955DEB214B2D48C7390ABFCA3459EEBA69950D637D2639356A87137D9E100D6B8004BCAFC10566CD2BDF4EB74B4629345A82B8DB62ACB05A62E57D4EF828E02DEF81AA5A9CA4FAC825E3EE285A69A77F62A1C5E444B0C461089965A5A296DC94925F4680A8D59C55A499AD56854EE811E914E35CEE2C459D6F78A16ECEC9BEA1E54717D8AD5FABBE10ADCBAE6A8CD682A5D5EAAED25DA13664F97C681BB6459551511C45B5E47678CCC13DAED90BBA9B33A9F4D9E0DF4A72F42B30DD115AEBB51F24A9F0D920FF5C7B0EA76368E353C401ED406558DF647CA4B6B364C3ED41FA37AB8D830D5E880D3722A5FB573736607D8915502AB999335EEA28D83C65D7002BA73F51A5EB0798F7BDD7213367675CBDBE25F8F5BDE4EB69F5BEEDA72971D3FD3899810B9AB13718B53BD4EA49D6C3F2762EA4D36BD191980A0EB4D35003DB00F9BE8423085201BC18CF4472812791BA32BB9EF46D99D7FAC556A6CB0DA447FBC7AF5C506ACCF0C91B02AC1D405ACC60F7CAB9D7CB3B9A4E45EE69D8DFC729CE77AEBBBC84EF26796F89E52D3138E75E2172E858464A4178CC23FC819C16ABFD5826B44F10484BC67BF83CAF0556EFAAED17FDEA0371C08119397D820C67AEB6B4BE343DB5D556F38C3DFAA33DC4018DC17A64F884733C47F48D0E2C7AD7BBD5BA135FBB75B81D57AB25B2135EBDE5B8175F54E63F52D77D33B1D20DF0B6F05EEE5F66D68612FBCB3B71755D94DBD4D3C95D5D2DBEAD2ECCC29D8ADB7AD80EAEDB40D7CF04E9D4A4B836C2BBCB6A6D7C60ECA6D7AF584DA65CBC9146037E90CD52BA91BB4AA366A2574BC89F7D24EFA165A48BDCE66CDF99A9AFEE0D6D3C6ADC343B587FE1F2D21B72CBDBE27D4D91232AF1AE5691E993A51E361DADB006DDDA2CE66511B6C7B0BA5AD8FD4D9466A836DED79ECA9C364EFB92AADAD6B2A393D9697D047EA2558CBAD6F56B1F6D22D725FE9EA1659FF0857B757E06905A1FF1F4E21AADD9F72CD273A61C5356E48542C6904E26B9048855E74CA259EA048AAE90884C8FE47F3159179F6687A84F813BD9DCB742ED596217924B5BF7E6977B08A7FD612ABCB3CBECD1213B18B2D2831B1CE1E6EE92F734CE252EECB96ECA10342FB993C45D667A99F62305D9648378CF604CAD557BAC77B4852A2C0C42D0DD11374CBB65E87758D8DCF319A7294881CA3A2573F95F9C5C9E2C37F45CCA60AD3300000, '5.0.0.net45')

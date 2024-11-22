—Ö
©D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Services\EntityServices\StaffRoleService\StaffRoleService.cs
	namespace 	
PracNet7ApiProB01
 
. 
Services $
.$ %
EntityServices% 3
.3 4
StaffRoleService4 D
{ 
public 

class 
StaffRoleService !
:" #
GenericService$ 2
<2 3
	StaffRole3 <
>< =
,= >
IStaffRoleService? P
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly 
IGenericRepository +
<+ ,
	StaffRole, 5
>5 6
_repository7 B
;B C
public 
StaffRoleService 
(   
PracNet7ApiDbContext  4
_context5 =
,= >
IUnitOfWork? J
_unitOfWorkK V
,V W
IGenericRepositoryX j
<j k
	StaffRolek t
>t u
_repository	v Å
)
Å Ç
:
É Ñ
base
Ö â
(
â ä
_context
ä í
,
í ì
_unitOfWork
î ü
,
ü †
_repository
° ¨
)
¨ ≠
{ 	
this 
. 
_context 
= 
_context $
;$ %
this 
. 
_unitOfWork 
= 
_unitOfWork *
;* +
this 
. 
_repository 
= 
_repository *
;* +
} 	
public 
async 
Task 
< 
object  
>  !
CreateNewStaffRole" 4
(4 5!
CreateStaffRoleReqDto5 J
modelK P
)P Q
{ 	
using   
(   
var   
transaction   "
=  # $
_context  % -
.  - .
Database  . 6
.  6 7
BeginTransaction  7 G
(  G H
)  H I
)  I J
{!! 
try"" 
{## 
var%% 
Id%% 
=%% 
Guid%% !
.%%! "
NewGuid%%" )
(%%) *
)%%* +
;%%+ ,
var,, 
_modelMapperConfig,, *
=,,+ ,
ModelMapperConfig,,- >
.,,> ?
IniializeAutoMapper,,? R
(,,R S
),,S T
;,,T U
var-- 
	staffRole-- !
=--" #
_modelMapperConfig--$ 6
.--6 7
Map--7 :
<--: ;!
CreateStaffRoleReqDto--; P
,--P Q
	StaffRole--R [
>--[ \
(--\ ]
model--] b
)--b c
;--c d
	staffRole.. 
... 
Id..  
=..! "
Id..# %
;..% &
_unitOfWork00 
.00  
StaffRoleRepository00  3
.003 4
	CreateNew004 =
(00= >
	staffRole00> G
)00G H
;00H I
int11 
created11 
=11  !
_unitOfWork11" -
.11- .
Save11. 2
(112 3
)113 4
;114 5
transaction22 
.22  
Commit22  &
(22& '
)22' (
;22( )
var44 
staffRoleCreated44 (
=44) *
_repository44+ 6
.446 7
FindById447 ?
(44? @
Id44@ B
)44B C
;44C D
return55 
await55  
Task55! %
.55% &

FromResult55& 0
(550 1
new551 4
CommonResponseDto555 F
<55F G
	StaffRole55G P
>55P Q
{66 
Status77 
=77  
HttpStatusCode77! /
.77/ 0
Created770 7
.777 8
ToString778 @
(77@ A
)77A B
,77B C
Message88 
=88  !
$"88" $
$str88$ @
"88@ A
,88A B

StatusCode99 "
=99# $
(99% &
int99& )
)99) *
HttpStatusCode99+ 9
.999 :
Created99: A
,99A B
Data:: 
=:: 
staffRoleCreated:: /
,::/ 0
};; 
);; 
;;; 
}<< 
catch== 
(== 
	Exception==  
)==  !
{>> 
string?? 

methodName?? %
=??& '
GeneralConfigs??( 6
.??6 7 
LogCurrentMethodName??7 K
(??K L
)??L M
;??M N
transaction@@ 
.@@  
Rollback@@  (
(@@( )
)@@) *
;@@* +
returnAA 
awaitAA  
TaskAA! %
.AA% &

FromResultAA& 0
(AA0 1
newAA1 4
CommonResponseDtoAA5 F
<AAF G
	StaffRoleAAG P
>AAP Q
{BB 
StatusCC 
=CC  
HttpStatusCodeCC! /
.CC/ 0
InternalServerErrorCC0 C
.CCC D
ToStringCCD L
(CCL M
)CCM N
,CCN O
MessageDD 
=DD  !
$"DD" $
$strDD$ ,
{DD, -

methodNameDD- 7
}DD7 8
$strDD8 Z
"DDZ [
,DD[ \

StatusCodeEE "
=EE# $
(EE% &
intEE& )
)EE) *
HttpStatusCodeEE* 8
.EE8 9
InternalServerErrorEE9 L
}GG 
)GG 
;GG 
}HH 
finallyII 
{JJ 
_contextKK 
.KK 
DisposeKK $
(KK$ %
)KK% &
;KK& '
}LL 
}MM 
}NN 	
publicRR 
asyncRR 
TaskRR 
<RR 
objectRR  
>RR  !
DeleteStaffRoleRR" 1
(RR1 2
stringRR2 8
staffRoleIdRR9 D
)RRD E
{SS 	
usingTT 
(TT 
varTT 
transactionTT "
=TT# $
_contextTT% -
.TT- .
DatabaseTT. 6
.TT6 7
BeginTransactionTT7 G
(TTG H
)TTH I
)TTI J
{UU 
tryVV 
{WW 
GuidXX 
StaffRoleUuidXX &
=XX' (
GuidXX) -
.XX- .
ParseXX. 3
(XX3 4
staffRoleIdXX4 ?
)XX? @
;XX@ A
varYY 
	staffRoleYY !
=YY" #
_repositoryYY$ /
.YY/ 0
FindByIdYY0 8
(YY8 9
StaffRoleUuidYY9 F
)YYF G
;YYG H
ifZZ 
(ZZ 
	staffRoleZZ !
==ZZ" $
nullZZ% )
)ZZ) *
{ZZ+ ,
return[[ 
await[[ $
Task[[% )
.[[) *

FromResult[[* 4
([[4 5
new[[5 8
CommonResponseDto[[9 J
<[[J K
	StaffRole[[K T
>[[T U
{\\ 
Status]] "
=]]# $
HttpStatusCode]]% 3
.]]3 4

BadRequest]]4 >
.]]> ?
ToString]]? G
(]]G H
)]]H I
,]]I J
Message^^ #
=^^$ %
$"^^& (
$str^^( C
"^^C D
,^^D E

StatusCode__ &
=__' (
(__) *
int__* -
)__- .
HttpStatusCode__/ =
.__= >

BadRequest__> H
}`` 
)`` 
;`` 
}aa 
elsebb 
{cc 
_unitOfWorkdd #
.dd# $
StaffRoleRepositorydd$ 7
.dd7 8
Deletedd8 >
(dd> ?
	staffRoledd? H
)ddH I
;ddI J
intee 
deletedee #
=ee$ %
_unitOfWorkee& 1
.ee1 2
Saveee2 6
(ee6 7
)ee7 8
;ee8 9
transactionff #
.ff# $
Commitff$ *
(ff* +
)ff+ ,
;ff, -
returnhh 
awaithh $
Taskhh% )
.hh) *

FromResulthh* 4
(hh4 5
newhh5 8
CommonResponseDtohh9 J
<hhJ K
	StaffRolehhK T
>hhT U
{ii 
Statusjj "
=jj# $
HttpStatusCodejj% 3
.jj3 4
OKjj4 6
.jj6 7
ToStringjj7 ?
(jj? @
)jj@ A
,jjA B
Messagekk #
=kk$ %
$"kk& (
$strkk( K
"kkK L
,kkL M

StatusCodell &
=ll' (
(ll) *
intll* -
)ll- .
HttpStatusCodell/ =
.ll= >
OKll> @
,ll@ A
}mm 
)mm 
;mm 
}nn 
}pp 
catchqq 
(qq 
	Exceptionqq  
)qq  !
{rr 
stringss 

methodNamess %
=ss& '
GeneralConfigsss( 6
.ss6 7 
LogCurrentMethodNamess7 K
(ssK L
)ssL M
;ssM N
transactiontt 
.tt  
Rollbacktt  (
(tt( )
)tt) *
;tt* +
returnuu 
awaituu  
Taskuu! %
.uu% &

FromResultuu& 0
(uu0 1
newuu1 4
CommonResponseDtouu5 F
<uuF G
	StaffRoleuuG P
>uuP Q
{vv 
Statusww 
=ww  
HttpStatusCodeww! /
.ww/ 0
InternalServerErrorww0 C
.wwC D
ToStringwwD L
(wwL M
)wwM N
,wwN O
Messagexx 
=xx  !
$"xx" $
$strxx$ ,
{xx, -

methodNamexx- 7
}xx7 8
$strxx8 Z
"xxZ [
,xx[ \

StatusCodeyy "
=yy# $
(yy% &
intyy& )
)yy) *
HttpStatusCodeyy* 8
.yy8 9
InternalServerErroryy9 L
}{{ 
){{ 
;{{ 
}|| 
finally}} 
{~~ 
_context 
. 
Dispose $
($ %
)% &
;& '
}
ÄÄ 
}
ÅÅ 
}
ÉÉ 	
public
áá 
async
áá 
Task
áá 
<
áá 
object
áá  
>
áá  !
UpdateStaffRole
áá" 1
(
áá1 2
string
áá2 8
staffRoleId
áá9 D
,
ááD E#
UpdateStaffRoleReqDto
ááF [
model
áá\ a
)
ááa b
{
àà 	
using
ââ 
(
ââ 
var
ââ 
transaction
ââ "
=
ââ# $
_context
ââ% -
.
ââ- .
Database
ââ. 6
.
ââ6 7
BeginTransaction
ââ7 G
(
ââG H
)
ââH I
)
ââI J
{
ää 
try
ãã 
{
åå 
Guid
çç 
staffRoleUuid
çç &
=
çç' (
Guid
çç) -
.
çç- .
Parse
çç. 3
(
çç3 4
staffRoleId
çç4 ?
)
çç? @
;
çç@ A
if
èè 
(
èè 
!
èè 
staffRoleUuid
èè &
.
èè& '
Equals
èè' -
(
èè- .
model
èè. 3
.
èè3 4
Id
èè4 6
)
èè6 7
)
èè7 8
{
êê 
return
ëë 
await
ëë $
Task
ëë% )
.
ëë) *

FromResult
ëë* 4
(
ëë4 5
new
ëë5 8
CommonResponseDto
ëë9 J
<
ëëJ K
	StaffRole
ëëK T
>
ëëT U
{
íí 
Status
ìì "
=
ìì" #
HttpStatusCode
ìì$ 2
.
ìì2 3

BadRequest
ìì3 =
.
ìì= >
ToString
ìì> F
(
ììF G
)
ììG H
,
ììH I
Message
îî #
=
îî$ %
$"
îî& (
$str
îî( V
"
îîV W
,
îîW X

StatusCode
ïï &
=
ïï& '
(
ïï( )
int
ïï) ,
)
ïï, -
HttpStatusCode
ïï- ;
.
ïï; <

BadRequest
ïï< F
}
ññ 
)
ññ 
;
ññ 
}
óó 
var
ôô 
	staffRole
ôô !
=
ôô" #
_unitOfWork
ôô$ /
.
ôô/ 0!
StaffRoleRepository
ôô0 C
.
ôôC D

FindById02
ôôD N
(
ôôN O
p
ôôO P
=>
ôôQ S
p
ôôT U
.
ôôU V
Id
ôôV X
==
ôôY [
model
ôô\ a
.
ôôa b
Id
ôôb d
)
ôôd e
;
ôôe f
if
õõ 
(
õõ 
	staffRole
õõ !
==
õõ" $
null
õõ% )
)
õõ) *
{
úú 
return
ùù 
await
ùù $
Task
ùù% )
.
ùù) *

FromResult
ùù* 4
(
ùù4 5
new
ùù5 8
CommonResponseDto
ùù9 J
<
ùùJ K
ProductBrand
ùùK W
>
ùùW X
{
ûû 
Status
üü "
=
üü# $
HttpStatusCode
üü% 3
.
üü3 4

BadRequest
üü4 >
.
üü> ?
ToString
üü? G
(
üüG H
)
üüH I
,
üüI J
Message
†† #
=
††$ %
$"
††& (
$str
††( C
"
††C D
,
††D E

StatusCode
°° &
=
°°' (
(
°°) *
int
°°* -
)
°°- .
HttpStatusCode
°°. <
.
°°< =

BadRequest
°°= G
}
¢¢ 
)
¢¢ 
;
¢¢ 
}
££ 
var
´´  
_modelMapperConfig
´´ *
=
´´+ ,
ModelMapperConfig
´´- >
.
´´> ?!
IniializeAutoMapper
´´? R
(
´´R S
)
´´S T
;
´´T U
var
¨¨ 
staffRoleUp
¨¨ #
=
¨¨$ % 
_modelMapperConfig
¨¨& 8
.
¨¨8 9
Map
¨¨9 <
<
¨¨< =#
UpdateStaffRoleReqDto
¨¨= R
,
¨¨R S
	StaffRole
¨¨T ]
>
¨¨] ^
(
¨¨^ _
model
¨¨_ d
)
¨¨d e
;
¨¨e f
_unitOfWork
ÆÆ 
.
ÆÆ  !
StaffRoleRepository
ÆÆ  3
.
ÆÆ3 4
Update
ÆÆ4 :
(
ÆÆ: ;
staffRoleUp
ÆÆ; F
)
ÆÆF G
;
ÆÆG H
int
ØØ 
updated
ØØ 
=
ØØ  !
_unitOfWork
ØØ" -
.
ØØ- .
Save
ØØ. 2
(
ØØ2 3
)
ØØ3 4
;
ØØ4 5
transaction
∞∞ 
.
∞∞  
Commit
∞∞  &
(
∞∞& '
)
∞∞' (
;
∞∞( )
var
≤≤ 
staffRoleUpdated
≤≤ (
=
≤≤) *
_repository
≤≤+ 6
.
≤≤6 7
FindById
≤≤7 ?
(
≤≤? @
staffRoleUuid
≤≤@ M
)
≤≤M N
;
≤≤N O
return
≥≥ 
await
≥≥  
Task
≥≥! %
.
≥≥% &

FromResult
≥≥& 0
(
≥≥0 1
new
≥≥1 4
CommonResponseDto
≥≥5 F
<
≥≥F G
	StaffRole
≥≥G P
>
≥≥P Q
{
≥≥R S
Status
¥¥ 
=
¥¥  
HttpStatusCode
¥¥! /
.
¥¥/ 0
OK
¥¥0 2
.
¥¥2 3
ToString
¥¥3 ;
(
¥¥; <
)
¥¥< =
,
¥¥= >
Message
µµ 
=
µµ  !
$"
µµ" $
$str
µµ$ G
"
µµG H
,
µµH I

StatusCode
∂∂ "
=
∂∂# $
(
∂∂% &
int
∂∂& )
)
∂∂) *
HttpStatusCode
∂∂* 8
.
∂∂8 9
OK
∂∂9 ;
,
∂∂; <
Data
∑∑ 
=
∑∑ 
staffRoleUpdated
∑∑ /
}
∏∏ 
)
∏∏ 
;
∏∏ 
}
ππ 
catch
∫∫ 
(
∫∫ 
	Exception
∫∫  
)
∫∫  !
{
ªª 
string
ºº 

methodName
ºº %
=
ºº& '
GeneralConfigs
ºº( 6
.
ºº6 7"
LogCurrentMethodName
ºº7 K
(
ººK L
)
ººL M
;
ººM N
transaction
ΩΩ 
.
ΩΩ  
Rollback
ΩΩ  (
(
ΩΩ( )
)
ΩΩ) *
;
ΩΩ* +
return
ææ 
await
ææ  
Task
ææ! %
.
ææ% &

FromResult
ææ& 0
(
ææ0 1
new
ææ1 4
CommonResponseDto
ææ5 F
<
ææF G
	StaffRole
ææG P
>
ææP Q
{
øø 
Status
¿¿ 
=
¿¿  
HttpStatusCode
¿¿! /
.
¿¿/ 0!
InternalServerError
¿¿0 C
.
¿¿C D
ToString
¿¿D L
(
¿¿L M
)
¿¿M N
,
¿¿N O
Message
¡¡ 
=
¡¡  !
$"
¡¡" $
$str
¡¡$ ,
{
¡¡, -

methodName
¡¡- 7
}
¡¡7 8
$str
¡¡8 Z
"
¡¡Z [
,
¡¡[ \

StatusCode
¬¬ "
=
¬¬# $
(
¬¬% &
int
¬¬& )
)
¬¬) *
HttpStatusCode
¬¬* 8
.
¬¬8 9!
InternalServerError
¬¬9 L
}
√√ 
)
√√ 
;
√√ 
}
ƒƒ 
finally
≈≈ 
{
∆∆ 
_context
«« 
.
«« 
Dispose
«« $
(
««$ %
)
««% &
;
««& '
}
»» 
}
…… 
}
   	
}
ÃÃ 
}ÕÕ √	
™D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Services\EntityServices\StaffRoleService\IStaffRoleService.cs
	namespace

 	
PracNet7ApiProB01


 
.

 
Services

 $
.

$ %
EntityServices

% 3
.

3 4
StaffRoleService

4 D
{ 
public 

	interface 
IStaffRoleService &
:' (
IGenericService) 8
<8 9
	StaffRole9 B
>B C
{ 
Task 
< 
object 
> 
CreateNewStaffRole '
(' (!
CreateStaffRoleReqDto( =
model> C
)C D
;D E
Task 
< 
object 
> 
UpdateStaffRole $
($ %
string% +
staffRoleId, 7
,7 8!
UpdateStaffRoleReqDto9 N
modelO T
)T U
;U V
Task 
< 
object 
> 
DeleteStaffRole $
($ %
string% +
staffRoleId, 7
)7 8
;8 9
} 
} Öp
•D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Services\EntityServices\ProductService\ProductService.cs
	namespace 	
PracNet7ApiProB01
 
. 
Services $
.$ %
EntityServices% 3
.3 4
ProductService4 B
{ 
public 

class 
ProductService 
:  !
GenericService" 0
<0 1
Product1 8
>8 9
,9 :
IProductService; J
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly 
IGenericRepository +
<+ ,
Product, 3
>3 4
_repository5 @
;@ A
public 
ProductService 
(  
PracNet7ApiDbContext 2
_context3 ;
,; <
IUnitOfWork= H
_unitOfWorkI T
,T U
IGenericRepositoryV h
<h i
Producti p
>p q
_repositoryr }
)} ~
:	 Ä
base
Å Ö
(
Ö Ü
_context
Ü é
,
é è
_unitOfWork
ê õ
,
õ ú
_repository
ù ®
)
® ©
{ 	
this 
. 
_context 
= 
_context $
;$ %
this 
. 
_unitOfWork 
= 
_unitOfWork *
;* +
this 
. 
_repository 
= 
_repository *
;* +
} 	
public 
async 
Task 
< 
object  
>  !
CreateNewProduct" 2
(2 3
CreateProductReqDto3 F
modelG L
)L M
{ 	
using 
( 
var 
transaction "
=# $
_context% -
.- .
Database. 6
.6 7
BeginTransaction7 G
(G H
)H I
)I J
{   
try!! 
{"" 
var%% 
Id%% 
=%% 
Guid%% !
.%%! "
NewGuid%%" )
(%%) *
)%%* +
;%%+ ,
var&& 
currentDate&& #
=&&$ %
DateTime&&& .
.&&. /
Now&&/ 2
;&&2 3
var.. 
_modelMapperConfig.. *
=..+ ,
ModelMapperConfig..- >
...> ?
IniializeAutoMapper..? R
(..R S
)..S T
;..T U
var// 
productEntity// %
=//& '
_modelMapperConfig//( :
.//: ;
Map//; >
<//> ?
CreateProductReqDto//? R
,//R S
Product//T [
>//[ \
(//\ ]
model//] b
)//b c
;//c d
productEntity00 !
.00! "
Id00" $
=00% &
Id00' )
;00) *
productEntity11 !
.11! "
DateOfCreate11" .
=11/ 0
currentDate111 <
;11< =
_unitOfWork22 
.22  
ProductRepository22  1
.221 2
	CreateNew222 ;
(22; <
productEntity22< I
)22I J
;22J K
int33 
created33 
=33  !
_unitOfWork33" -
.33- .
Save33. 2
(332 3
)333 4
;334 5
transaction44 
.44  
Commit44  &
(44& '
)44' (
;44( )
var66 
productCreated66 &
=66' (
_repository66) 4
.664 5
FindById665 =
(66= >
Id66> @
)66@ A
;66A B
return88 
await88  
Task88! %
.88% &

FromResult88& 0
(880 1
new99 
CommonResponseDto99 -
<99- .
Product99. 5
>995 6
{:: 
Status;; "
=;;# $
HttpStatusCode;;% 3
.;;3 4
Created;;4 ;
.;;; <
ToString;;< D
(;;D E
);;E F
,;;F G
Message<< #
=<<$ %
$"<<& (
$str<<( A
"<<A B
,<<B C
Data==  
===! "
productCreated==# 1
}>> 
)?? 
;?? 
}AA 
catchBB 
(BB 
	ExceptionBB  
)BB  !
{CC 
transactionDD 
.DD  
RollbackDD  (
(DD( )
)DD) *
;DD* +
throwEE 
;EE 
}FF 
finallyGG 
{GG 
_unitOfWorkGG %
.GG% &
DisposeGG& -
(GG- .
)GG. /
;GG/ 0
}GG1 2
}HH 
}JJ 	
publicNN 
asyncNN 
TaskNN 
<NN 
objectNN  
>NN  !
DeleteProductNN" /
(NN/ 0
stringNN0 6
	productIdNN7 @
)NN@ A
{OO 	
usingPP 
(PP 
varPP 
transactionPP "
=PP# $
_contextPP% -
.PP- .
DatabasePP. 6
.PP6 7
BeginTransactionPP7 G
(PPG H
)PPH I
)PPI J
{QQ 
tryRR 
{SS 
GuidTT 
productUuidTT $
=TT% &
GuidTT' +
.TT+ ,
ParseTT, 1
(TT1 2
	productIdTT2 ;
)TT; <
;TT< =
varUU 
productUU 
=UU  !
_repositoryUU" -
.UU- .
FindByIdUU. 6
(UU6 7
productUuidUU7 B
)UUB C
;UUC D
ifVV 
(VV 
productVV 
==VV  "
nullVV# '
)VV' (
{WW 
returnXX 
awaitXX $
TaskXX% )
.XX) *

FromResultXX* 4
(XX4 5
newXX5 8
CommonResponseDtoXX9 J
<XXJ K
ProductXXK R
>XXR S
{YY 
StatusZZ "
=ZZ# $
HttpStatusCodeZZ% 3
.ZZ3 4

BadRequestZZ4 >
.ZZ> ?
ToStringZZ? G
(ZZG H
)ZZH I
,ZZI J
Message[[ #
=[[$ %
$"[[& (
$str[[( @
"[[@ A
}\\ 
)\\ 
;\\ 
}]] 
else^^ 
{__ 
_unitOfWork`` #
.``# $
ProductRepository``$ 5
.``5 6
Delete``6 <
(``< =
product``= D
)``D E
;``E F
intaa 
deletedaa #
=aa$ %
_unitOfWorkaa& 1
.aa1 2
Saveaa2 6
(aa6 7
)aa7 8
;aa8 9
transactionbb #
.bb# $
Commitbb$ *
(bb* +
)bb+ ,
;bb, -
returncc 
awaitcc $
Taskcc% )
.cc) *

FromResultcc* 4
(cc4 5
newcc5 8
CommonResponseDtocc9 J
<ccJ K
ProductccK R
>ccR S
{dd 
Statusee "
=ee# $
HttpStatusCodeee% 3
.ee3 4
OKee4 6
.ee6 7
ToStringee7 ?
(ee? @
)ee@ A
,eeA B
Messageff #
=ff$ %
$"ff& (
$strff( E
"ffE F
,ffF G

StatusCodegg &
=gg' (
$numgg) ,
,gg, -
}hh 
)hh 
;hh 
}ii 
}jj 
catchkk 
(kk 
	Exceptionkk  
)kk  !
{ll 
transactionmm 
.mm  
Rollbackmm  (
(mm( )
)mm* +
;mm+ ,
thrownn 
;nn 
}oo 
finallypp 
{qq 
_contextrr 
.rr 
Disposerr $
(rr$ %
)rr% &
;rr& '
}ss 
}tt 
}uu 	
publicyy 
asyncyy 
Taskyy 
<yy 
objectyy  
>yy  !'
GetAllProductsWithSubObjectyy" =
(yy= >
)yy> ?
{zz 	
var{{ 
proList{{ 
={{ 
_repository{{ %
.{{% &
FindAllInclude{{& 4
({{4 5
p{{5 6
=>{{7 9
p{{: ;
.{{; <
ProductBrand{{< H
){{H I
;{{I J
return|| 
await|| 
Task|| 
.|| 

FromResult|| (
(||( )
proList||) 0
)||0 1
;||1 2
}}} 	
public
ÅÅ 
async
ÅÅ 
Task
ÅÅ 
<
ÅÅ 
object
ÅÅ  
>
ÅÅ  !
UpdateProduct
ÅÅ" /
(
ÅÅ/ 0
string
ÅÅ0 6
	productId
ÅÅ7 @
,
ÅÅ@ A!
UpdateProductReqDto
ÅÅB U
model
ÅÅV [
)
ÅÅ[ \
{
ÇÇ 	
using
ÉÉ 
(
ÉÉ 
var
ÉÉ 
transaction
ÉÉ "
=
ÉÉ# $
_context
ÉÉ% -
.
ÉÉ- .
Database
ÉÉ. 6
.
ÉÉ6 7
BeginTransaction
ÉÉ7 G
(
ÉÉG H
)
ÉÉH I
)
ÉÉI J
{
ÑÑ 
try
ÖÖ 
{
ÜÜ 
Guid
áá 
productUUid
áá $
=
áá% &
Guid
áá' +
.
áá+ ,
Parse
áá, 1
(
áá1 2
	productId
áá2 ;
)
áá; <
;
áá< =
if
ââ 
(
ââ 
!
ââ 
productUUid
ââ $
.
ââ$ %
Equals
ââ% +
(
ââ+ ,
model
ââ, 1
.
ââ1 2
Id
ââ2 4
)
ââ4 5
)
ââ5 6
{
ââ7 8
return
ää 
await
ää $
Task
ää% )
.
ää) *

FromResult
ää* 4
(
ää4 5
new
ää5 8
CommonResponseDto
ää9 J
<
ääJ K
Product
ääK R
>
ääR S
{
ãã 
Status
åå "
=
åå# $
HttpStatusCode
åå% 3
.
åå3 4

BadRequest
åå4 >
.
åå> ?
ToString
åå? G
(
ååG H
)
ååH I
,
ååI J
Message
çç #
=
çç$ %
$"
çç& (
$str
çç( V
"
ççV W
}
éé 
)
éé 
;
éé 
}
èè 
var
ëë 
product
ëë 
=
ëë  !
_unitOfWork
ëë" -
.
ëë- .
ProductRepository
ëë. ?
.
ëë? @

FindById02
ëë@ J
(
ëëJ K
p
ëëK L
=>
ëëM O
p
ëëP Q
.
ëëQ R
Id
ëëR T
==
ëëU W
model
ëëX ]
.
ëë] ^
Id
ëë^ `
)
ëë` a
;
ëëa b
if
ìì 
(
ìì 
product
ìì 
==
ìì  "
null
ìì# '
)
ìì' (
{
îî 
return
ïï 
await
ïï $
Task
ïï% )
.
ïï) *

FromResult
ïï* 4
(
ïï4 5
new
ïï5 8
CommonResponseDto
ïï9 J
<
ïïJ K
Product
ïïK R
>
ïïR S
{
ññ 
Status
óó "
=
óó# $
HttpStatusCode
óó% 3
.
óó3 4

BadRequest
óó4 >
.
óó> ?
ToString
óó? G
(
óóG H
)
óóH I
,
óóI J
Message
òò #
=
òò$ %
$"
òò& (
$str
òò( @
"
òò@ A
}
ôô 
)
ôô 
;
ôô 
}
öö 
var
££  
_modelMapperConfig
££ *
=
££+ ,
ModelMapperConfig
££- >
.
££> ?!
IniializeAutoMapper
££? R
(
££R S
)
££S T
;
££T U
var
•• 
	productUp
•• !
=
••" # 
_modelMapperConfig
••$ 6
.
••6 7
Map
••7 :
<
••: ;!
UpdateProductReqDto
••; N
,
••N O
Product
••P W
>
••W X
(
••X Y
model
••Y ^
)
••^ _
;
••_ `
	productUp
¶¶ 
.
¶¶ 
DateOfUpdate
¶¶ *
=
¶¶+ ,
DateTime
¶¶- 5
.
¶¶5 6
Now
¶¶6 9
;
¶¶9 :
	productUp
ßß 
.
ßß 
DateOfCreate
ßß *
=
ßß+ ,
product
ßß- 4
.
ßß4 5
DateOfCreate
ßß5 A
;
ßßA B
_unitOfWork
®® 
.
®®  
ProductRepository
®®  1
.
®®1 2
Update
®®2 8
(
®®8 9
	productUp
®®9 B
)
®®B C
;
®®C D
int
©© 
updated
©© 
=
©©  !
_unitOfWork
©©" -
.
©©- .
Save
©©. 2
(
©©2 3
)
©©3 4
;
©©4 5
transaction
™™ 
.
™™  
Commit
™™  &
(
™™& '
)
™™' (
;
™™( )
var
¨¨ 
productUpdated
¨¨ &
=
¨¨' (
_repository
¨¨) 4
.
¨¨4 5
FindById
¨¨5 =
(
¨¨= >
model
¨¨> C
.
¨¨C D
Id
¨¨D F
)
¨¨F G
;
¨¨G H
return
≠≠ 
await
≠≠  
Task
≠≠! %
.
≠≠% &

FromResult
≠≠& 0
(
≠≠0 1
new
≠≠1 4
CommonResponseDto
≠≠5 F
<
≠≠F G
Product
≠≠G N
>
≠≠N O
{
ÆÆ 
Status
ØØ 
=
ØØ  
HttpStatusCode
ØØ! /
.
ØØ/ 0
OK
ØØ0 2
.
ØØ2 3
ToString
ØØ3 ;
(
ØØ; <
)
ØØ< =
,
ØØ= >
Message
∞∞ 
=
∞∞  !
$"
∞∞" $
$str
∞∞$ @
"
∞∞@ A
,
∞∞A B
Data
±± 
=
±± 
productUpdated
±± -
,
±±- .
}
≤≤ 
)
≤≤ 
;
≤≤ 
}
≥≥ 
catch
¥¥ 
(
¥¥ 
	Exception
¥¥  
)
¥¥  !
{
µµ 
transaction
∂∂ 
.
∂∂  
Rollback
∂∂  (
(
∂∂( )
)
∂∂) *
;
∂∂* +
throw
∑∑ 
;
∑∑ 
}
∏∏ 
finally
ππ 
{
∫∫ 
_context
ªª 
.
ªª 
Dispose
ªª $
(
ªª$ %
)
ªª% &
;
ªª& '
}
ºº 
}
ΩΩ 
}
ææ 	
}
¿¿ 
}¡¡ ≈

¶D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Services\EntityServices\ProductService\IProductService.cs
	namespace 	
PracNet7ApiProB01
 
. 
Services $
.$ %
EntityServices% 3
.3 4
ProductService4 B
{ 
public 

	interface 
IProductService $
:% &
IGenericService' 6
<6 7
Product7 >
>> ?
{ 
Task 
< 
object 
> 
CreateNewProduct %
(% &
CreateProductReqDto& 9
model: ?
)? @
;@ A
Task 
< 
object 
> 
UpdateProduct "
(" #
string# )
	productId* 3
,3 4
UpdateProductReqDto5 H
modelI N
)N O
;O P
Task 
< 
object 
> 
DeleteProduct "
(" #
string# )
	productId* 3
)3 4
;4 5
Task 
< 
object 
> '
GetAllProductsWithSubObject 0
(0 1
)1 2
;2 3
} 
}   •k
ØD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Services\EntityServices\ProductBrandService\ProductBrandService.cs
	namespace 	
PracNet7ApiProB01
 
. 
Services $
.$ %
EntityServices% 3
.3 4
ProductBrandService4 G
{ 
public 

class 
ProductBrandService $
:% &
GenericService' 5
<5 6
ProductBrand6 B
>B C
,C D 
IProductBrandServiceE Y
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly 
IGenericRepository +
<+ ,
ProductBrand, 8
>8 9
_repository: E
;E F
public 
ProductBrandService "
(" # 
PracNet7ApiDbContext# 7
_context8 @
,@ A
IUnitOfWorkB M
_unitOfWorkN Y
,Y Z
IGenericRepository[ m
<m n
ProductBrandn z
>z {
_repository	| á
)
á à
:
â ä
base
ã è
(
è ê
_context
ê ò
,
ò ô
_unitOfWork
ö •
,
• ¶
_repository
ß ≤
)
≤ ≥
{ 	
this 
. 
_context 
= 
_context $
;$ %
this 
. 
_unitOfWork 
= 
_unitOfWork *
;* +
this 
. 
_repository 
= 
_repository *
;* +
} 	
public 
async 
Task 
< 
object  
>  !!
CreateNewProductBrand" 7
(7 8$
CreateProductBrandReqDto8 P
modelQ V
)V W
{ 	
using 
( 
var 
transaction "
=# $
_context% -
.- .
Database. 6
.6 7
BeginTransaction7 G
(G H
)H I
)I J
{   
try!! 
{"" 
var%% 
Id%% 
=%% 
Guid%% !
.%%! "
NewGuid%%" )
(%%) *
)%%* +
;%%+ ,
var,, 
_modelMapperConfig,, *
=,,+ ,
ModelMapperConfig,,- >
.,,> ?
IniializeAutoMapper,,? R
(,,R S
),,S T
;,,T U
var-- 
productBrand-- $
=--% &
_modelMapperConfig--' 9
.--9 :
Map--: =
<--= >$
CreateProductBrandReqDto--> V
,--V W
ProductBrand--X d
>--d e
(--e f
model--f k
)--k l
;--l m
productBrand..  
...  !
Id..! #
=..$ %
Id..& (
;..( )
productBrand//  
.//  !
DateOfCreate//! -
=//. /
DateTime//0 8
.//8 9
Now//9 <
;//< =
_unitOfWork11 
.11  "
ProductBrandRepository11  6
.116 7
	CreateNew117 @
(11@ A
productBrand11A M
)11M N
;11N O
int22 
created22 
=22  !
_unitOfWork22" -
.22- .
Save22. 2
(222 3
)223 4
;224 5
transaction33 
.33  
Commit33  &
(33& '
)33' (
;33( )
var55 
proBrandCreated55 '
=55( )
_repository55* 5
.555 6
FindById556 >
(55> ?
Id55? A
)55A B
;55B C
return66 
await66  
Task66! %
.66% &

FromResult66& 0
(660 1
new661 4
CommonResponseDto665 F
<66F G
ProductBrand66G S
>66S T
{77 
Status88 
=88  
HttpStatusCode88! /
.88/ 0
Created880 7
.887 8
ToString888 @
(88@ A
)88A B
,88B C
Message99 
=99  !
$"99" $
$str99$ C
"99C D
,99D E
Data:: 
=:: 
proBrandCreated:: .
,::. /
};; 
);; 
;;; 
}<< 
catch== 
(== 
	Exception==  
)==  !
{>> 
transaction?? 
.??  
Rollback??  (
(??( )
)??) *
;??* +
throw@@ 
;@@ 
}AA 
finallyBB 
{CC 
_contextDD 
.DD 
DisposeDD $
(DD$ %
)DD% &
;DD& '
}EE 
}FF 
}GG 	
publicKK 
asyncKK 
TaskKK 
<KK 
objectKK  
>KK  !
DeleteProductBrandKK" 4
(KK4 5
stringKK5 ;
productBrandIdKK< J
)KKJ K
{LL 	
usingMM 
(MM 
varMM 
transactionMM "
=MM# $
_contextMM% -
.MM- .
DatabaseMM. 6
.MM6 7
BeginTransactionMM7 G
(MMG H
)MMH I
)MMI J
{NN 
tryOO 
{PP 
GuidQQ 
productBrandUuidQQ )
=QQ* +
GuidQQ, 0
.QQ0 1
ParseQQ1 6
(QQ6 7
productBrandIdQQ7 E
)QQE F
;QQF G
varRR 
productBrandRR $
=RR% &
_repositoryRR' 2
.RR2 3
FindByIdRR3 ;
(RR; <
productBrandUuidRR< L
)RRL M
;RRM N
ifSS 
(SS 
productBrandSS $
==SS% '
nullSS( ,
)SS, -
{TT 
returnUU 
awaitUU $
TaskUU% )
.UU) *

FromResultUU* 4
(UU4 5
newUU5 8
CommonResponseDtoUU9 J
<UUJ K
ProductBrandUUK W
>UUW X
{VV 
StatusWW "
=WW# $
HttpStatusCodeWW% 3
.WW3 4

BadRequestWW4 >
.WW> ?
ToStringWW? G
(WWG H
)WWH I
,WWI J
MessageXX #
=XX$ %
$"XX& (
$strXX( F
"XXF G
}YY 
)YY 
;YY 
}ZZ 
else[[ 
{\\ 
_unitOfWork]] #
.]]# $"
ProductBrandRepository]]$ :
.]]: ;
Delete]]; A
(]]A B
productBrand]]B N
)]]N O
;]]O P
int^^ 
deleted^^ #
=^^$ %
_unitOfWork^^& 1
.^^1 2
Save^^2 6
(^^6 7
)^^7 8
;^^8 9
transaction__ #
.__# $
Commit__$ *
(__* +
)__+ ,
;__, -
return`` 
await`` $
Task``% )
.``) *

FromResult``* 4
(``4 5
new``5 8
CommonResponseDto``9 J
<``J K
ProductBrand``K W
>``W X
{aa 
Statusbb "
=bb# $
HttpStatusCodebb% 3
.bb3 4
OKbb4 6
.bb6 7
ToStringbb7 ?
(bb? @
)bb@ A
,bbA B
Messagecc #
=cc$ %
$"cc& (
$strcc( K
"ccK L
,ccL M

StatusCodedd &
=dd' (
$numdd) ,
,dd, -
}ee 
)ee 
;ee 
}ff 
}gg 
catchhh 
(hh 
	Exceptionhh  
)hh  !
{ii 
transactionjj 
.jj  
Rollbackjj  (
(jj( )
)jj) *
;jj* +
throwkk 
;kk 
}ll 
finallymm 
{nn 
_unitOfWorkoo 
.oo  
Disposeoo  '
(oo' (
)oo( )
;oo) *
}pp 
}qq 
}rr 	
publicvv 
asyncvv 
Taskvv 
<vv 
objectvv  
>vv  !
UpdateProductBrandvv" 4
(vv4 5
stringvv5 ;
productBrandIdvv< J
,vvJ K$
UpdateProductBrandReqDtovvL d
modelvve j
)vvj k
{ww 	
usingxx 
(xx 
varxx 
transactionxx "
=xx# $
_contextxx% -
.xx- .
Databasexx. 6
.xx6 7
BeginTransactionxx7 G
(xxG H
)xxH I
)xxI J
{yy 
tryzz 
{{{ 
Guid|| 
productBrandUuid|| )
=||* +
Guid||, 0
.||0 1
Parse||1 6
(||6 7
productBrandId||7 E
)||E F
;||F G
if~~ 
(~~ 
!~~ 
productBrandUuid~~ )
.~~) *
Equals~~* 0
(~~0 1
model~~1 6
.~~6 7
Id~~7 9
)~~9 :
)~~: ;
{ 
return
ÄÄ 
await
ÄÄ $
Task
ÄÄ% )
.
ÄÄ) *

FromResult
ÄÄ* 4
(
ÄÄ4 5
new
ÄÄ5 8
CommonResponseDto
ÄÄ9 J
<
ÄÄJ K
ProductBrand
ÄÄK W
>
ÄÄW X
{
ÅÅ 
Status
ÇÇ "
=
ÇÇ# $
HttpStatusCode
ÇÇ% 3
.
ÇÇ3 4

BadRequest
ÇÇ4 >
.
ÇÇ> ?
ToString
ÇÇ? G
(
ÇÇG H
)
ÇÇH I
,
ÇÇI J
Message
ÉÉ #
=
ÉÉ$ %
$"
ÉÉ& (
$str
ÉÉ( V
"
ÉÉV W
}
ÑÑ 
)
ÑÑ 
;
ÑÑ 
}
ÖÖ 
var
áá 
productBrand
áá $
=
áá% &
_unitOfWork
áá' 2
.
áá2 3$
ProductBrandRepository
áá3 I
.
ááI J

FindById02
ááJ T
(
ááT U
p
ááU V
=>
ááW Y
p
ááZ [
.
áá[ \
Id
áá\ ^
==
áá_ a
model
ááb g
.
áág h
Id
ááh j
)
ááj k
;
áák l
if
ââ 
(
ââ 
productBrand
ââ $
==
ââ% '
null
ââ( ,
)
ââ, -
{
ää 
return
ãã 
await
ãã $
Task
ãã% )
.
ãã) *

FromResult
ãã* 4
(
ãã4 5
new
ãã5 8
CommonResponseDto
ãã9 J
<
ããJ K
ProductBrand
ããK W
>
ããW X
{
åå 
Status
çç "
=
çç# $
HttpStatusCode
çç% 3
.
çç3 4

BadRequest
çç4 >
.
çç> ?
ToString
çç? G
(
ççG H
)
ççH I
,
ççI J
Message
éé #
=
éé$ %
$"
éé& (
$str
éé( F
"
ééF G
}
èè 
)
èè 
;
èè 
}
êê 
var
òò  
_modelMapperConfig
òò *
=
òò+ ,
ModelMapperConfig
òò- >
.
òò> ?!
IniializeAutoMapper
òò? R
(
òòR S
)
òòS T
;
òòT U
var
ôô 

proBrandUp
ôô "
=
ôô# $ 
_modelMapperConfig
ôô% 7
.
ôô7 8
Map
ôô8 ;
<
ôô; <&
UpdateProductBrandReqDto
ôô< T
,
ôôT U
ProductBrand
ôôV b
>
ôôb c
(
ôôc d
model
ôôd i
)
ôôi j
;
ôôj k

proBrandUp
öö 
.
öö 
DateOfUpdate
öö +
=
öö, -
DateTime
öö. 6
.
öö6 7
Now
öö7 :
;
öö: ;

proBrandUp
õõ 
.
õõ 
DateOfCreate
õõ +
=
õõ, -
productBrand
õõ. :
.
õõ: ;
DateOfCreate
õõ; G
;
õõG H
_unitOfWork
ùù 
.
ùù  $
ProductBrandRepository
ùù  6
.
ùù6 7
Update
ùù7 =
(
ùù= >

proBrandUp
ùù> H
)
ùùH I
;
ùùI J
int
ûû 
updated
ûû 
=
ûû  !
_unitOfWork
ûû" -
.
ûû- .
Save
ûû. 2
(
ûû2 3
)
ûû3 4
;
ûû4 5
transaction
üü 
.
üü  
Commit
üü  &
(
üü& '
)
üü' (
;
üü( )
var
°° !
productBrandUpdated
°° +
=
°°, -
_repository
°°. 9
.
°°9 :
FindById
°°: B
(
°°B C
productBrandUuid
°°C S
)
°°S T
;
°°T U
return
¢¢ 
await
¢¢  
Task
¢¢! %
.
¢¢% &

FromResult
¢¢& 0
(
¢¢0 1
new
¢¢1 4
CommonResponseDto
¢¢5 F
<
¢¢F G
ProductBrand
¢¢G S
>
¢¢S T
{
££ 
Status
§§ 
=
§§  
HttpStatusCode
§§! /
.
§§/ 0
OK
§§0 2
.
§§2 3
ToString
§§3 ;
(
§§; <
)
§§< =
,
§§= >
Message
•• 
=
••  !
$"
••" $
$str
••$ F
"
••F G
,
••G H
Data
¶¶ 
=
¶¶ !
productBrandUpdated
¶¶ 2
,
¶¶2 3
}
ßß 
)
ßß 
;
ßß 
}
®® 
catch
©© 
(
©© 
	Exception
©©  
)
©©  !
{
™™ 
transaction
´´ 
.
´´  
Rollback
´´  (
(
´´( )
)
´´) *
;
´´* +
throw
¨¨ 
;
¨¨ 
}
≠≠ 
finally
ÆÆ 
{
ØØ 
_unitOfWork
∞∞ 
.
∞∞  
Dispose
∞∞  '
(
∞∞' (
)
∞∞( )
;
∞∞) *
}
±± 
}
≤≤ 
}
≥≥ 	
}
µµ 
}∂∂ Á	
∞D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Services\EntityServices\ProductBrandService\IProductBrandService.cs
	namespace

 	
PracNet7ApiProB01


 
.

 
Services

 $
.

$ %
EntityServices

% 3
.

3 4
ProductBrandService

4 G
{ 
public 

	interface  
IProductBrandService )
:* +
IGenericService, ;
<; <
ProductBrand< H
>H I
{ 
Task 
< 
object 
> !
CreateNewProductBrand *
(* +$
CreateProductBrandReqDto+ C
modelD I
)I J
;J K
Task 
< 
object 
> 
UpdateProductBrand '
(' (
string( .
productBrandId/ =
,= >$
UpdateProductBrandReqDto? W
modelX ]
)] ^
;^ _
Task 
< 
object 
> 
DeleteProductBrand '
(' (
string( .
productBrandId/ =
)= >
;> ?
} 
} ﬂ
∂D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Services\EntityServices\GeneralUserInfoService\IGeneralUserInfoService.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Services		 $
.		$ %
EntityServices		% 3
.		3 4"
GeneralUserInfoService		4 J
{

 
public 

	interface #
IGeneralUserInfoService ,
:- .
IGenericService/ >
<> ?
GeneralUserInfo? N
>N O
{ 
} 
} Ù
µD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Services\EntityServices\GeneralUserInfoService\GeneralUserInfoService.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Services		 $
.		$ %
EntityServices		% 3
.		3 4"
GeneralUserInfoService		4 J
{

 
public 

class "
GeneralUserInfoService '
:( )
GenericService* 8
<8 9
GeneralUserInfo9 H
>H I
,I J#
IGeneralUserInfoServiceK b
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
public "
GeneralUserInfoService %
(% & 
PracNet7ApiDbContext& :
_context; C
,C D
IUnitOfWorkE P
_unitOfWorkQ \
,\ ]
IGenericRepository^ p
<p q
GeneralUserInfo	q Ä
>
Ä Å
_repository
Ç ç
)
ç é
:
è ê
base
ë ï
(
ï ñ
_context
ñ û
,
û ü
_unitOfWork
† ´
,
´ ¨
_repository
≠ ∏
)
∏ π
{ 	
this 
. 
_context 
= 
_context $
;$ %
this 
. 
_unitOfWork 
= 
_unitOfWork *
;* +
} 	
} 
} √	
ÆD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Services\EntityServices\GeneralRoleService\IGeneralRoleService.cs
	namespace

 	
PracNet7ApiProB01


 
.

 
Services

 $
.

$ %
EntityServices

% 3
.

3 4
GeneralRoleService

4 F
{ 
public 

	interface 
IGeneralRoleService (
:) *
IGenericService+ :
<: ;
GeneralRole; F
>F G
{ 
Task 
< 
object 
> 
CreateNewGenRole %
(% &#
CreateGeneralRoleReqDro& =
model> C
)C D
;D E
Task 
< 
object 
> 
UpdateGenRole "
(" #
string# )
	genRoleId* 3
,3 4
UpdateGenRoleReqDto5 H
modelI N
)N O
;O P
Task 
< 
object 
> 
DeleteGenRole "
(" #
string# )
	genRoleId* 3
)3 4
;4 5
} 
} ¨ó
≠D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Services\EntityServices\GeneralRoleService\GeneralRoleService.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Services		 $
.		$ %
EntityServices		% 3
.		3 4
GeneralRoleService		4 F
{

 
public 

class 
GeneralRoleService #
:$ %
GenericService& 4
<4 5
GeneralRole5 @
>@ A
,A B
IGeneralRoleServiceC V
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly 
IGenericRepository +
<+ ,
GeneralRole, 7
>7 8
_repository9 D
;D E
public 
GeneralRoleService !
(! " 
PracNet7ApiDbContext" 6
_context7 ?
,? @
IUnitOfWorkA L
_unitOfWorkM X
,X Y
IGenericRepositoryZ l
<l m
GeneralRolem x
>x y
_repository	z Ö
)
Ö Ü
:
á à
base
â ç
(
ç é
_context
é ñ
,
ñ ó
_unitOfWork
ò £
,
£ §
_repository
• ∞
)
∞ ±
{ 	
this 
. 
_context 
= 
_context $
;$ %
this 
. 
_unitOfWork 
= 
_unitOfWork *
;* +
this 
. 
_repository 
= 
_repository *
;* +
} 	
public 
async 
Task 
< 
object  
>  !
CreateNewGenRole" 2
(2 3#
CreateGeneralRoleReqDro3 J
modelK P
)P Q
{   	
using!! 
(!! 
var!! 
transaction!! "
=!!# $
_context!!% -
.!!- .
Database!!. 6
.!!6 7
BeginTransaction!!7 G
(!!G H
)!!H I
)!!I J
{"" 
try## 
{$$ 
var%% 
genRoleCode%% #
=%%$ %
_unitOfWork%%& 1
.%%1 2!
GeneralRoleRepository%%2 G
.%%G H
FindByCondition%%H W
(%%W X
e%%X Y
=>%%Z \
e%%] ^
.%%^ _
GenRoleCode%%_ j
.%%j k
Equals%%k q
(%%q r
model%%r w
.%%w x
GenRoleCode	%%x É
)
%%É Ñ
)
%%Ñ Ö
.
%%Ö Ü
FirstOrDefault
%%Ü î
(
%%î ï
)
%%ï ñ
;
%%ñ ó
if&& 
(&& 
genRoleCode&& #
!=&&$ &
null&&' +
)&&+ ,
{'' 
return(( 
await(( $
Task((% )
.(() *

FromResult((* 4
(((4 5
new((5 8
CommonResponseDto((9 J
<((J K
GeneralRole((K V
>((V W
{)) 
Status** "
=**# $
HttpStatusCode**% 3
.**3 4

BadRequest**4 >
.**> ?
ToString**? G
(**G H
)**H I
,**I J
Message++ #
=++$ %
$"++& (
$str++( 6
{++6 7
genRoleCode++7 B
.++B C
GenRoleCode++C N
}++N O
$str++O `
"++` a
,++a b
},, 
),, 
;,, 
}-- 
var// 
genRoleTitle// $
=//% &
_unitOfWork//' 2
.//2 3!
GeneralRoleRepository//3 H
.//H I
FindByCondition//I X
(//X Y
e//Y Z
=>//[ ]
e//^ _
.//_ `
GenRoleTitle//` l
.//l m
Equals//m s
(//s t
model//t y
.//y z
GenRoleTitle	//z Ü
)
//Ü á
)
//á à
.
//à â
FirstOrDefault
//â ó
(
//ó ò
)
//ò ô
;
//ô ö
if11 
(11 
genRoleTitle11 $
!=11% '
null11( ,
)11, -
{22 
return33 
await33 $
Task33% )
.33) *

FromResult33* 4
(334 5
new335 8
CommonResponseDto339 J
<33J K
GeneralRole33K V
>33V W
{44 
Status55 "
=55# $
HttpStatusCode55% 3
.553 4

BadRequest554 >
.55> ?
ToString55? G
(55G H
)55H I
,55I J
Message66 #
=66$ %
$"66& (
$str66( 7
{667 8
genRoleTitle668 D
.66D E
GenRoleTitle66E Q
}66Q R
$str66R c
"66c d
,66d e
}77 
)77 
;77 
}88 
var:: 
Id:: 
=:: 
Guid:: !
.::! "
NewGuid::" )
(::) *
)::* +
;::+ ,
GeneralRole<< 
generalRole<<  +
=<<, -
new<<. 1
GeneralRole<<2 =
(<<= >
)<<> ?
{== 
Id>> 
=>> 
Id>> 
,>>  
GenRoleCode?? #
=??$ %
model??& +
.??+ ,
GenRoleCode??, 7
,??7 8
GenRoleTitle@@ $
=@@% &
model@@' ,
.@@, -
GenRoleTitle@@- 9
,@@9 :
}AA 
;AA 
_unitOfWorkCC 
.CC  !
GeneralRoleRepositoryCC  5
.CC5 6
	CreateNewCC6 ?
(CC? @
generalRoleCC@ K
)CCK L
;CCL M
intDD 
createdDD 
=DD  !
_unitOfWorkDD" -
.DD- .
SaveDD. 2
(DD2 3
)DD3 4
;DD4 5
transactionEE 
.EE  
CommitEE  &
(EE& '
)EE' (
;EE( )
varGG 
genCodeCreatedGG &
=GG' (
_repositoryGG) 4
.GG4 5
FindByIdGG5 =
(GG= >
IdGG> @
)GG@ A
;GGA B
returnHH 
awaitHH  
TaskHH! %
.HH% &

FromResultHH& 0
(HH0 1
newHH1 4
CommonResponseDtoHH5 F
<HHF G
GeneralRoleHHG R
>HHR S
{II 
StatusJJ 
=JJ  
HttpStatusCodeJJ! /
.JJ/ 0
CreatedJJ0 7
.JJ7 8
ToStringJJ8 @
(JJ@ A
)JJA B
,JJB C
MessageKK 
=KK  !
$"KK" $
$strKK$ B
"KKB C
,KKC D
DataLL 
=LL 
genCodeCreatedLL -
,LL- .
}MM 
)MM 
;MM 
}OO 
catchPP 
(PP 
	ExceptionPP  
)PP  !
{QQ 
transactionRR 
.RR  
RollbackRR  (
(RR( )
)RR) *
;RR* +
throwSS 
;SS 
}TT 
finallyUU 
{UU 
_unitOfWorkUU %
.UU% &
DisposeUU& -
(UU- .
)UU. /
;UU/ 0
}UU1 2
}VV 
}WW 	
public[[ 
async[[ 
Task[[ 
<[[ 
object[[  
>[[  !
DeleteGenRole[[" /
([[/ 0
string[[0 6
	genRoleId[[7 @
)[[@ A
{\\ 	
using]] 
(]] 
var]] 
transaction]] "
=]]# $
_context]]% -
.]]- .
Database]]. 6
.]]6 7
BeginTransaction]]7 G
(]]G H
)]]H I
)]]I J
{^^ 
try__ 
{`` 
Guidaa 
genRoleUuidaa $
=aa% &
Guidaa' +
.aa+ ,
Parseaa, 1
(aa1 2
	genRoleIdaa2 ;
)aa; <
;aa< =
varbb 
genRolebb 
=bb  !
_unitOfWorkbb" -
.bb- .!
GeneralRoleRepositorybb. C
.bbC D
FindByIdbbD L
(bbL M
genRoleUuidbbM X
)bbX Y
;bbY Z
ifcc 
(cc 
genRolecc 
==cc  "
nullcc# '
)cc' (
{dd 
returnee 
awaitee $
Taskee% )
.ee) *

FromResultee* 4
(ee4 5
newee5 8
CommonResponseDtoee9 J
<eeJ K
GeneralRoleeeK V
>eeV W
{ff 
Statusgg "
=gg# $
HttpStatusCodegg% 3
.gg3 4

BadRequestgg4 >
.gg> ?
ToStringgg? G
(ggG H
)ggH I
,ggI J
Messagehh #
=hh$ %
$"hh& (
$strhh( E
"hhE F
}ii 
)ii 
;ii 
}jj 
elsekk 
{ll 
_unitOfWorkmm #
.mm# $!
GeneralRoleRepositorymm$ 9
.mm9 :
Deletemm: @
(mm@ A
genRolemmA H
)mmH I
;mmI J
intnn 
deletednn #
=nn$ %
_unitOfWorknn& 1
.nn1 2
Savenn2 6
(nn6 7
)nn7 8
;nn8 9
transactionoo #
.oo# $
Commitoo$ *
(oo* +
)oo+ ,
;oo, -
returnpp 
awaitpp $
Taskpp% )
.pp) *

FromResultpp* 4
(pp4 5
newpp5 8
CommonResponseDtopp9 J
<ppJ K
GeneralRoleppK V
>ppV W
{qq 
Statusrr "
=rr# $
HttpStatusCoderr% 3
.rr3 4
OKrr4 6
.rr6 7
ToStringrr7 ?
(rr? @
)rr@ A
,rrA B
Messagess #
=ss$ %
$"ss& (
$strss( J
"ssJ K
,ssK L

StatusCodett &
=tt' (
$numtt) ,
,tt, -
}uu 
)uu 
;uu 
}vv 
}ww 
catchxx 
(xx 
	Exceptionxx  
)xx  !
{yy 
transactionzz 
.zz  
Rollbackzz  (
(zz( )
)zz) *
;zz* +
throw{{ 
;{{ 
}|| 
finally}} 
{~~ 
_unitOfWork 
.  
Dispose  '
(' (
)( )
;) *
}
ÄÄ 
}
ÅÅ 
}
ÇÇ 	
public
åå 
async
åå 
Task
åå 
<
åå 
object
åå  
>
åå  !
UpdateGenRole
åå" /
(
åå/ 0
string
åå0 6
	genRoleId
åå7 @
,
åå@ A!
UpdateGenRoleReqDto
ååB U
model
ååV [
)
åå[ \
{
çç 	
using
éé 
(
éé 
var
éé 
transaction
éé "
=
éé# $
_context
éé% -
.
éé- .
Database
éé. 6
.
éé6 7
BeginTransaction
éé7 G
(
ééG H
)
ééH I
)
ééI J
{
èè 
try
êê 
{
ëë 
Guid
íí 
genRoleUuid
íí $
=
íí% &
Guid
íí' +
.
íí+ ,
Parse
íí, 1
(
íí1 2
	genRoleId
íí2 ;
)
íí; <
;
íí< =
if
îî 
(
îî 
!
îî 
genRoleUuid
îî $
.
îî$ %
Equals
îî% +
(
îî+ ,
model
îî, 1
.
îî1 2
Id
îî2 4
)
îî4 5
)
îî5 6
{
ïï 
return
ññ 
await
ññ $
Task
ññ% )
.
ññ) *

FromResult
ññ* 4
(
ññ4 5
new
ññ5 8
CommonResponseDto
ññ9 J
<
ññJ K
GeneralRole
ññK V
>
ññV W
{
óó 
Status
òò "
=
òò# $
HttpStatusCode
òò% 3
.
òò3 4

BadRequest
òò4 >
.
òò> ?
ToString
òò? G
(
òòG H
)
òòH I
,
òòI J
Message
ôô #
=
ôô$ %
$"
ôô& (
$str
ôô( V
"
ôôV W
}
öö 
)
öö 
;
öö 
}
õõ 
var
ùù 
genRole
ùù 
=
ùù  !
_unitOfWork
ùù" -
.
ùù- .#
GeneralRoleRepository
ùù. C
.
ùùC D
FindById
ùùD L
(
ùùL M
genRoleUuid
ùùM X
)
ùùX Y
;
ùùY Z
if
üü 
(
üü 
genRole
üü 
==
üü  "
null
üü# '
)
üü' (
{
†† 
return
°° 
await
°° $
Task
°°% )
.
°°) *

FromResult
°°* 4
(
°°4 5
new
°°5 8
CommonResponseDto
°°9 J
<
°°J K
GeneralRole
°°K V
>
°°V W
{
¢¢ 
Status
££ "
=
££# $
HttpStatusCode
££% 3
.
££3 4

BadRequest
££4 >
.
££> ?
ToString
££? G
(
££G H
)
££H I
,
££I J
Message
§§ #
=
§§$ %
$"
§§& (
$str
§§( E
"
§§E F
}
•• 
)
•• 
;
•• 
}
¶¶ 
else
ßß 
{
®® 
if
©© 
(
©© 
genRole
©© #
.
©©# $
GenRoleCode
©©$ /
.
©©/ 0
Equals
©©0 6
(
©©6 7
model
©©7 <
.
©©< =
GenRoleCode
©©= H
)
©©H I
&&
©©J L
genRole
©©M T
.
©©T U
GenRoleTitle
©©U a
.
©©a b
Equals
©©b h
(
©©h i
model
©©i n
.
©©n o
GenRoleTitle
©©o {
)
©©{ |
)
©©| }
{
™™ 
genRole
´´ #
.
´´# $
GenRoleTitle
´´$ 0
=
´´1 2
model
´´3 8
.
´´8 9
GenRoleTitle
´´9 E
;
´´E F
genRole
¨¨ #
.
¨¨# $
GenRoleCode
¨¨$ /
=
¨¨0 1
model
¨¨2 7
.
¨¨7 8
GenRoleCode
¨¨8 C
;
¨¨C D
}
≠≠ 
else
ÆÆ 
{
ØØ 
var
∞∞ 
genRoleCode
∞∞  +
=
∞∞, -
_unitOfWork
∞∞. 9
.
∞∞9 :#
GeneralRoleRepository
∞∞: O
.
∞∞O P
FindByCondition
∞∞P _
(
∞∞_ `
e
∞∞` a
=>
∞∞b d
e
∞∞e f
.
∞∞f g
GenRoleCode
∞∞g r
.
∞∞r s
Equals
∞∞s y
(
∞∞y z
model
∞∞z 
.∞∞ Ä
GenRoleCode∞∞Ä ã
)∞∞ã å
)∞∞å ç
.∞∞ç é
FirstOrDefault∞∞é ú
(∞∞ú ù
)∞∞ù û
;∞∞û ü
if
±± 
(
±±  
genRoleCode
±±  +
!=
±±, .
null
±±/ 3
)
±±3 4
{
≤≤ 
return
≥≥  &
await
≥≥' ,
Task
≥≥- 1
.
≥≥1 2

FromResult
≥≥2 <
(
≥≥< =
new
≥≥= @
CommonResponseDto
≥≥A R
<
≥≥R S
GeneralRole
≥≥S ^
>
≥≥^ _
{
¥¥  !
Status
µµ$ *
=
µµ+ ,
HttpStatusCode
µµ- ;
.
µµ; <

BadRequest
µµ< F
.
µµF G
ToString
µµG O
(
µµO P
)
µµP Q
,
µµQ R
Message
∂∂$ +
=
∂∂, -
$"
∂∂. 0
$str
∂∂0 >
{
∂∂> ?
genRoleCode
∂∂? J
.
∂∂J K
GenRoleCode
∂∂K V
}
∂∂V W
$str
∂∂W h
"
∂∂h i
}
∑∑  !
)
∑∑! "
;
∑∑" #
}
∏∏ 
var
∫∫ 
genRoleTitle
∫∫  ,
=
∫∫- .
_unitOfWork
∫∫/ :
.
∫∫: ;#
GeneralRoleRepository
∫∫; P
.
∫∫P Q
FindByCondition
∫∫Q `
(
∫∫` a
e
∫∫a b
=>
∫∫c e
e
∫∫f g
.
∫∫g h
GenRoleTitle
∫∫h t
.
∫∫t u
Equals
∫∫u {
(
∫∫{ |
model∫∫| Å
.∫∫Å Ç
GenRoleTitle∫∫Ç é
)∫∫é è
)∫∫è ê
.∫∫ê ë
FirstOrDefault∫∫ë ü
(∫∫ü †
)∫∫† °
;∫∫° ¢
if
ºº 
(
ºº  
genRoleTitle
ºº  ,
!=
ºº- /
null
ºº0 4
)
ºº4 5
{
ΩΩ 
return
ææ  &
await
ææ' ,
Task
ææ- 1
.
ææ1 2

FromResult
ææ2 <
(
ææ< =
new
ææ= @
CommonResponseDto
ææA R
<
ææR S
GeneralRole
ææS ^
>
ææ^ _
{
øø  !
Status
¿¿$ *
=
¿¿+ ,
HttpStatusCode
¿¿- ;
.
¿¿; <

BadRequest
¿¿< F
.
¿¿F G
ToString
¿¿G O
(
¿¿O P
)
¿¿P Q
,
¿¿Q R
Message
¡¡$ +
=
¡¡, -
$"
¡¡. 0
$str
¡¡0 ?
{
¡¡? @
genRoleTitle
¡¡@ L
.
¡¡L M
GenRoleTitle
¡¡M Y
}
¡¡Y Z
$str
¡¡Z k
"
¡¡k l
}
¬¬  !
)
¬¬! "
;
¬¬" #
}
√√ 
genRole
≈≈ #
.
≈≈# $
GenRoleTitle
≈≈$ 0
=
≈≈1 2
model
≈≈3 8
.
≈≈8 9
GenRoleTitle
≈≈9 E
;
≈≈E F
genRole
∆∆ #
.
∆∆# $
GenRoleCode
∆∆$ /
=
∆∆0 1
model
∆∆2 7
.
∆∆7 8
GenRoleCode
∆∆8 C
;
∆∆C D
}
«« 
}
»» 
_unitOfWork
   
.
    #
GeneralRoleRepository
    5
.
  5 6
Update
  6 <
(
  < =
genRole
  = D
)
  D E
;
  E F
int
ÀÀ 
updated
ÀÀ 
=
ÀÀ  !
_unitOfWork
ÀÀ" -
.
ÀÀ- .
Save
ÀÀ. 2
(
ÀÀ2 3
)
ÀÀ3 4
;
ÀÀ4 5
transaction
ÃÃ 
.
ÃÃ  
Commit
ÃÃ  &
(
ÃÃ& '
)
ÃÃ' (
;
ÃÃ( )
var
ŒŒ 
genCodeUpdated
ŒŒ &
=
ŒŒ' (
_repository
ŒŒ) 4
.
ŒŒ4 5
FindById
ŒŒ5 =
(
ŒŒ= >
genRoleUuid
ŒŒ> I
)
ŒŒI J
;
ŒŒJ K
return
œœ 
await
œœ  
Task
œœ! %
.
œœ% &

FromResult
œœ& 0
(
œœ0 1
new
œœ1 4
CommonResponseDto
œœ5 F
<
œœF G
GeneralRole
œœG R
>
œœR S
{
–– 
Status
—— 
=
——  
HttpStatusCode
——! /
.
——/ 0
Created
——0 7
.
——7 8
ToString
——8 @
(
——@ A
)
——A B
,
——B C
Message
““ 
=
““  !
$"
““" $
$str
““$ E
"
““E F
,
““F G
Data
”” 
=
”” 
genCodeUpdated
”” -
,
””- .
}
‘‘ 
)
‘‘ 
;
‘‘ 
}
’’ 
catch
÷÷ 
(
÷÷ 
	Exception
÷÷  
)
÷÷  !
{
◊◊ 
transaction
ÿÿ 
.
ÿÿ  
Rollback
ÿÿ  (
(
ÿÿ( )
)
ÿÿ) *
;
ÿÿ* +
throw
ŸŸ 
;
ŸŸ 
}
⁄⁄ 
finally
€€ 
{
€€ 
_unitOfWork
€€ %
.
€€% &
Dispose
€€& -
(
€€- .
)
€€. /
;
€€/ 0
}
€€1 2
}
‹‹ 
}
›› 	
}
ﬁﬁ 
}ﬂﬂ 
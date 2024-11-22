ô
D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01\WeatherForecast.cs
	namespace 	
PracNet7ApiProB01
 
{ 
public 

class 
WeatherForecast  
{ 
public 
DateOnly 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
TemperatureC 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
int		 
TemperatureF		 
=>		  "
$num		# %
+		& '
(		( )
int		) ,
)		, -
(		- .
TemperatureC		. :
/		; <
$num		= C
)		C D
;		D E
public 
string 
? 
Summary 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} π
wD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
builder 
. 
Services 
. 
AddDbContext 
<  
PracNet7ApiDbContext 2
>2 3
(3 4
options4 ;
=>< >
options? F
.F G
	UseNpgsqlG P
(P Q
builderQ X
.X Y
ConfigurationY f
.f g
GetConnectionStringg z
(z {
$str	{ é
)
é è
)
è ê
)
ê ë
;
ë í
Log 
. 
Logger 

= 
new 
LoggerConfiguration $
($ %
)% &
.& '
ReadFrom' /
./ 0
Configuration0 =
(= >
builder> E
.E F
ConfigurationF S
)S T
.T U
CreateLoggerU a
(a b
)b c
;c d
builder 
. 
Services 
. 
AddTransient 
< 
IUnitOfWork )
,) *

UnitOfWork+ 5
>5 6
(6 7
)7 8
;8 9
builder 
. 
Services 
. 
AddMvc 
( 
) 
. 
AddJsonOptions 
( 
x 
=> 
x 
. !
JsonSerializerOptions 0
.0 1
ReferenceHandler1 A
=B C
ReferenceHandlerD T
.T U
IgnoreCyclesU a
)a b
;b c
builder"" 
."" 
Host"" 
."" 

UseSerilog"" 
("" 
)"" 
;"" 
builder%% 
.%% 
Services%% 
.%% 
AddCors%% 
(%% 
)%% 
;%% 
var'' 
app'' 
='' 	
builder''
 
.'' 
Build'' 
('' 
)'' 
;'' 
if++ 
(++ 
app++ 
.++ 
Environment++ 
.++ 
IsDevelopment++ !
(++! "
)++" #
)++# $
{,, 
app-- 
.-- 

UseSwagger-- 
(-- 
)-- 
;-- 
app.. 
... 
UseSwaggerUI.. 
(.. 
).. 
;.. 
}// 
app22 
.22 
UseCors22 
(22 
C22 
=>22 
C22 
.22 
AllowAnyHeader22 !
(22! "
)22" #
.22# $
AllowAnyMethod22$ 2
(222 3
)223 4
.224 5
AllowAnyOrigin225 C
(22C D
)22D E
)22E F
;22F G
app55 
.55 $
UseSerilogRequestLogging55 
(55 
)55 
;55 
app77 
.77 
UseHttpsRedirection77 
(77 
)77 
;77 
app99 
.99 
UseAuthorization99 
(99 
)99 
;99 
app;; 
.;; 
MapControllers;; 
(;; 
);; 
;;; 
app== 
.== 
Run== 
(== 
)== 	
;==	 
¨
ïD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01\Controllers\WeatherForecastController.cs
	namespace 	
PracNet7ApiProB01
 
. 
Controllers '
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class %
WeatherForecastController *
:+ ,
ControllerBase- ;
{ 
private		 
static		 
readonly		 
string		  &
[		& '
]		' (
	Summaries		) 2
=		3 4
new		5 8
[		8 9
]		9 :
{

 	
$str 
, 
$str !
,! "
$str# +
,+ ,
$str- 3
,3 4
$str5 ;
,; <
$str= C
,C D
$strE L
,L M
$strN S
,S T
$strU a
,a b
$strc n
} 	
;	 

private 
readonly 
ILogger  
<  !%
WeatherForecastController! :
>: ;
_logger< C
;C D
public %
WeatherForecastController (
(( )
ILogger) 0
<0 1%
WeatherForecastController1 J
>J K
loggerL R
)R S
{ 	
_logger 
= 
logger 
; 
} 	
[ 	
HttpGet	 
( 
Name 
= 
$str ,
), -
]- .
public 
IEnumerable 
< 
WeatherForecast *
>* +
Get, /
(/ 0
)0 1
{ 	
return 

Enumerable 
. 
Range #
(# $
$num$ %
,% &
$num' (
)( )
.) *
Select* 0
(0 1
index1 6
=>7 9
new: =
WeatherForecast> M
{ 
Date 
= 
DateOnly 
.  
FromDateTime  ,
(, -
DateTime- 5
.5 6
Now6 9
.9 :
AddDays: A
(A B
indexB G
)G H
)H I
,I J
TemperatureC 
= 
Random %
.% &
Shared& ,
., -
Next- 1
(1 2
-2 3
$num3 5
,5 6
$num7 9
)9 :
,: ;
Summary 
= 
	Summaries #
[# $
Random$ *
.* +
Shared+ 1
.1 2
Next2 6
(6 7
	Summaries7 @
.@ A
LengthA G
)G H
]H I
} 
) 
. 
ToArray 
( 
) 
; 
} 	
}   
}!! „p
èD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01\Controllers\StaffRoleController.cs
	namespace 	
PracNet7ApiProB01
 
. 
Controllers '
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
StaffRoleController $
:% &
ControllerBase' 5
{ 
private 
readonly 
IUnitOfWork $
_iUnitOfWork% 1
;1 2
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
private 
readonly 
IGenericRepository +
<+ ,
	StaffRole, 5
>5 6
_staffRoleRepo7 E
;E F
private 
readonly 
IStaffRoleService *
_staffRoleService+ <
;< =
public 
StaffRoleController "
(" #
IUnitOfWork# .
_iUnitOfWork/ ;
,; < 
PracNet7ApiDbContext= Q
_contextR Z
)Z [
{ 	
this 
. 
_iUnitOfWork 
= 
_iUnitOfWork  ,
;, -
this 
. 
_context 
= 
_context $
;$ %
this 
. 
_staffRoleRepo 
=  !
new" %
StaffRoleRepository& 9
(9 :
_context: B
)B C
;C D
this 
. 
_staffRoleService "
=# $
new% (
StaffRoleService* :
(: ;
_context; C
,C D
_iUnitOfWorkE Q
,Q R
_staffRoleRepoS a
)a b
;b c
} 	
[   	
HttpGet  	 
(   
$str   #
)  # $
]  $ %
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
GetAllStaffRoles!!) 9
(!!9 :
)!!: ;
{"" 	
List## 
<## 
	StaffRole## 
>## 

staffRoles## &
=##' (
_staffRoleService##) :
.##: ;
FindAll##; B
(##B C
)##C D
;##D E
string$$ 
funcName$$ 
=$$ 
GeneralConfigs$$ ,
.$$, - 
LogCurrentMethodName$$- A
($$A B
)$$B C
;$$C D
Log&& 
.&& 
Information&& 
(&& 
$str&& H
,&&H I
funcName&&J R
,&&R S
DateTime&&T \
.&&\ ]
Now&&] `
,&&` a

staffRoles&&b l
)&&l m
;&&m n
return(( 
await(( 
Task(( 
.(( 

FromResult(( (
(((( )

StatusCode(() 3
(((3 4
StatusCodes((4 ?
.((? @
Status200OK((@ K
,((K L

staffRoles((M W
)((W X
)((X Y
;((Y Z
})) 	
[-- 	
HttpGet--	 
(-- 
$str-- .
)--. /
]--/ 0
public.. 
async.. 
Task.. 
<.. 
IActionResult.. '
>..' (
GetStaffRoleById..) 9
(..9 :
[..: ;
	FromRoute..; D
(..D E
Name..E I
=..J K
$str..L Y
)..Y Z
]..Z [
string..\ b
id..c e
)..e f
{// 	
Guid00 
staffRoleId00 
=00 
Guid00 #
.00# $
Parse00$ )
(00) *
id00* ,
)00, -
;00- .
	StaffRole11 
	staffRole11 
=11  !
_staffRoleService11" 3
.113 4
FindById114 <
(11< =
staffRoleId11= H
)11H I
;11I J
string22 
funcName22 
=22 
GeneralConfigs22 ,
.22, - 
LogCurrentMethodName22- A
(22A B
)22B C
;22C D
Log33 
.33 
Information33 
(33 
$str33 H
,33H I
funcName33J R
,33R S
DateTime33T \
.33\ ]
Now33] `
,33` a
	staffRole33b k
)33k l
;33l m
return44 
await44 
Task44 
.44 

FromResult44 (
(44( )

StatusCode44) 3
(443 4
StatusCodes444 ?
.44? @
Status200OK44@ K
,44K L
	staffRole44M V
)44V W
)44W X
;44X Y
}55 	
[:: 	
HttpPost::	 
(:: 
$str:: #
)::# $
]::$ %
public;; 
async;; 
Task;; 
<;; 
IActionResult;; '
>;;' (
CreateNewStaffRole;;) ;
(;;; <
[;;< =
FromBody;;= E
];;E F!
CreateStaffRoleReqDto;;G \
model;;] b
);;b c
{<< 	
CommonResponseDto== 
<== 
	StaffRole== '
>==' (
created==) 0
===1 2
(==3 4
CommonResponseDto==4 E
<==E F
	StaffRole==F O
>==O P
)==P Q
await==Q V
_staffRoleService==W h
.==h i
CreateNewStaffRole==i {
(=={ |
model	==| Å
)
==Å Ç
;
==Ç É
string>> 
funcName>> 
=>> 
GeneralConfigs>> ,
.>>, - 
LogCurrentMethodName>>- A
(>>A B
)>>B C
;>>C D
if@@ 
(@@ 
created@@ 
.@@ 
Data@@ 
!=@@ 
null@@  $
)@@$ %
{AA 
createdBB 
.BB 

StatusCodeBB "
=BB# $
StatusCodesBB% 0
.BB0 1
Status201CreatedBB1 A
;BBA B
LogCC 
.CC 
InformationCC 
(CC  
$strCC  K
,CCK L
funcNameCCM U
,CCU V
DateTimeCCV ^
.CC^ _
NowCC_ b
,CCb c
createdCCd k
)CCk l
;CCl m
returnDD 
awaitDD 
TaskDD !
.DD! "

FromResultDD" ,
(DD, -

StatusCodeDD- 7
(DD7 8
StatusCodesDD8 C
.DDC D
Status201CreatedDDD T
,DDT U
newDDV Y
{EE 

StatusCodeFF 
=FF  
StatusCodesFF! ,
.FF, -
Status201CreatedFF- =
,FF= >
ResponseModelGG !
=GG" #
createdGG$ +
,GG+ ,
}HH 
)HH 
)HH 
;HH 
}II 
elseJJ 
{KK 
createdLL 
.LL 

StatusCodeLL "
=LL# $
StatusCodesLL% 0
.LL0 1
Status400BadRequestLL1 D
;LLD E
LogMM 
.MM 
InformationMM 
(MM  
$strMM  [
,MM[ \
funcNameMM] e
,MMe f
DateTimeMMg o
.MMo p
NowMMp s
,MMs t
createdMMu |
)MM| }
;MM} ~
returnNN 
awaitNN 
TaskNN !
.NN! "

FromResultNN" ,
(NN, -

StatusCodeNN- 7
(NN7 8
StatusCodesNN8 C
.NNC D
Status400BadRequestNND W
,NNW X
newNNY \
{NN] ^

StatusCodeNN_ i
=NNj k
StatusCodesNNl w
.NNw x 
Status400BadRequest	NNx ã
,
NNã å
ResponseModel
NNç ö
=
NNõ ú
created
NNù §
}
NN• ¶
)
NN¶ ß
)
NNß ®
;
NN® ©
}OO 
}PP 	
[UU 	
HttpPutUU	 
(UU 
$strUU 0
)UU0 1
]UU1 2
publicVV 
asyncVV 
TaskVV 
<VV 
IActionResultVV '
>VV' (
UpdateStaffRoleVV) 8
(VV8 9
[VV9 :
	FromRouteVV: C
(VVC D
NameVVD H
=VVI J
$strVVK X
)VVX Y
]VVY Z
stringVV[ a
idVVb d
,VVd e
[VVf g
FromBodyVVg o
]VVo p"
UpdateStaffRoleReqDto	VVq Ü
model
VVá å
)
VVå ç
{WW 	
CommonResponseDtoXX 
<XX 
	StaffRoleXX '
>XX' (
updatedXX) 0
=XX1 2
(XX3 4
CommonResponseDtoXX4 E
<XXE F
	StaffRoleXXF O
>XXO P
)XXP Q
awaitXXQ V
_staffRoleServiceXXW h
.XXh i
UpdateStaffRoleXXi x
(XXx y
idXXy {
,XX{ |
model	XX} Ç
)
XXÇ É
;
XXÉ Ñ
stringYY 
funcNameYY 
=YY 
GeneralConfigsYY ,
.YY, - 
LogCurrentMethodNameYY- A
(YYA B
)YYB C
;YYC D
if[[ 
([[ 
updated[[ 
.[[ 
Data[[ 
!=[[ 
null[[  $
)[[$ %
{\\ 
updated]] 
.]] 

StatusCode]] "
=]]# $
$num]]% (
;]]( )
Log^^ 
.^^ 
Information^^ 
(^^  
$str^^  _
,^^_ `
funcName^^a i
,^^i j
id^^k m
,^^m n
DateTime^^o w
.^^w x
Now^^x {
,^^{ |
updated	^^} Ñ
)
^^Ñ Ö
;
^^Ö Ü
return__ 
await__ 
Task__ !
.__! "

FromResult__" ,
(__, -

StatusCode__- 7
(__7 8
StatusCodes__8 C
.__C D
Status200OK__D O
,__O P
new__Q T
{`` 

StatusCodeaa 
=aa  
StatusCodesaa! ,
.aa, -
Status200OKaa- 8
,aa8 9
ResponseModelbb !
=bb" #
updatedbb$ +
}cc 
)cc 
)cc 
;cc 
}dd 
elseee 
{ff 
updatedgg 
.gg 

StatusCodegg "
=gg# $
StatusCodesgg% 0
.gg0 1
Status400BadRequestgg1 D
;ggD E
Loghh 
.hh 
Informationhh 
(hh  
$strhh  a
,hha b
funcNamehhc k
,hhk l
idhhm o
,hho p
DateTimehhq y
.hhy z
Nowhhz }
,hh} ~
updated	hh Ü
)
hhÜ á
;
hhá à
returnii 
awaitii 
Taskii !
.ii! "

FromResultii" ,
(ii, -

StatusCodeii- 7
(ii7 8
StatusCodesii8 C
.iiC D
Status400BadRequestiiD W
,iiW X
newiiY \
{ii] ^

StatusCodeii_ i
=iij k
StatusCodesiil w
.iiw x 
Status400BadRequest	iix ã
,
iiã å
ResponseModel
iiç ö
=
iiõ ú
updated
iiù §
}
ii• ¶
)
ii¶ ß
)
iiß ®
;
ii® ©
}jj 
}ll 	
[qq 	

HttpDeleteqq	 
(qq 
$strqq 0
)qq0 1
]qq1 2
publicrr 
asyncrr 
Taskrr 
<rr 
IActionResultrr '
>rr' (
DeleteStaffRolerr) 8
(rr8 9
[rr9 :
	FromRouterr: C
(rrC D
NamerrD H
=rrI J
$strrrK X
)rrX Y
]rrY Z
stringrr[ a
idrrb d
)rrd e
{ss 	
CommonResponseDtott 
<tt 
	StaffRolett '
>tt' (
deletedtt) 0
=tt1 2
(tt3 4
CommonResponseDtott4 E
<ttE F
	StaffRolettF O
>ttO P
)ttP Q
awaitttQ V
_staffRoleServicettW h
.tth i
DeleteStaffRoletti x
(ttx y
idtty {
)tt{ |
;tt| }
stringuu 
funcNameuu 
=uu 
GeneralConfigsuu ,
.uu, - 
LogCurrentMethodNameuu- A
(uuA B
)uuB C
;uuC D
ifww 
(ww 
deletedww 
.ww 

StatusCodeww "
==ww# %
StatusCodesww& 1
.ww1 2
Status200OKww2 =
)ww= >
{xx 
Logyy 
.yy 
Informationyy 
(yy  
$stryy  Z
,yyZ [
funcNameyy\ d
,yyd e
idyye g
,yyg h
DateTimeyyi q
.yyq r
Nowyyr u
)yyu v
;yyv w
returnzz 
awaitzz 
Taskzz !
.zz! "

FromResultzz" ,
(zz, -

StatusCodezz- 7
(zz7 8
StatusCodeszz8 C
.zzC D
Status200OKzzD O
,zzO P
newzzQ T
{{{ 

StatusCode|| 
=||  
StatusCodes||! ,
.||, -
Status200OK||- 8
,||8 9
ResponseModel}} !
=}}" #
deleted}}$ +
}~~ 
)~~ 
)~~ 
;~~ 
} 
else
ÄÄ 
{
ÅÅ 
deleted
ÇÇ 
.
ÇÇ 

StatusCode
ÇÇ "
=
ÇÇ# $
StatusCodes
ÇÇ% 0
.
ÇÇ0 1!
Status400BadRequest
ÇÇ1 D
;
ÇÇD E
Log
ÉÉ 
.
ÉÉ 
Information
ÉÉ 
(
ÉÉ  
$str
ÉÉ  \
,
ÉÉ\ ]
funcName
ÉÉ^ f
,
ÉÉf g
id
ÉÉh j
,
ÉÉj k
DateTime
ÉÉl t
.
ÉÉt u
Now
ÉÉu x
)
ÉÉx y
;
ÉÉy z
return
ÑÑ 
await
ÑÑ 
Task
ÑÑ !
.
ÑÑ! "

FromResult
ÑÑ" ,
(
ÑÑ, -

StatusCode
ÑÑ- 7
(
ÑÑ7 8
StatusCodes
ÑÑ8 C
.
ÑÑC D!
Status400BadRequest
ÑÑD W
,
ÑÑW X
new
ÑÑY \
{
ÑÑ] ^

StatusCode
ÑÑ_ i
=
ÑÑj k
StatusCodes
ÑÑl w
.
ÑÑw x"
Status400BadRequestÑÑx ã
,ÑÑã å
ResponseModelÑÑç ö
=ÑÑõ ú
deletedÑÑù §
}ÑÑ• ¶
)ÑÑ¶ ß
)ÑÑß ®
;ÑÑ® ©
}
ÖÖ 
}
ÜÜ 	
}
ââ 
}ää Ûq
çD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01\Controllers\ProductController.cs
	namespace 	
PracNet7ApiProB01
 
. 
Controllers '
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
ProductController "
:# $
ControllerBase% 3
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly 
IProductRepository +
_productRepository, >
;> ?
private 
readonly 
IProductService (
_productService) 8
;8 9
public 
ProductController  
(  !
IUnitOfWork! ,

unitOfWork- 7
,7 8 
PracNet7ApiDbContext9 M
contextN U
)U V
{ 	
this 
. 
_context 
= 
context #
;# $
this 
. 
_unitOfWork 
= 

unitOfWork )
;) *
this 
. 
_productRepository #
=$ %
new& )
ProductRepository* ;
(; <
_context< D
)D E
;E F
this 
. 
_productService  
=! "
new# &
ProductService' 5
(5 6
_context6 >
,> ?
_unitOfWork@ K
,K L
thisM Q
.Q R
_productRepositoryR d
)d e
;e f
} 	
["" 	
HttpGet""	 
("" 
$str"" 
)"" 
]"" 
public## 
async## 
Task## 
<## 
IActionResult## '
>##' (
GetAllProducts##) 7
(##7 8
)##8 9
{$$ 	
List%% 
<%% 
Product%% 
>%% 
products%% "
=%%# $
_productService%%% 4
.%%4 5
FindAll%%5 <
(%%< =
)%%= >
;%%> ?
Log&& 
.&& 
Information&& 
(&& 
$str&& J
,&&J K
DateTime&&L T
.&&T U
Now&&U X
,&&X Y
products&&Z b
)&&b c
;&&c d
return'' 
await'' 
Task'' 
.'' 

FromResult'' (
(''( )

StatusCode'') 3
(''3 4
StatusCodes''4 ?
.''? @
Status200OK''@ K
,''K L
products''M U
)''U V
)''V W
;''W X
}(( 	
[-- 	
HttpGet--	 
(-- 
$str-- %
)--% &
]--& '
public.. 
async.. 
Task.. 
<.. 
IActionResult.. '
>..' (
GetProductById..) 7
(..7 8
[..8 9
	FromRoute..9 B
(..B C
Name..C G
=..H I
$str..J Q
)..Q R
]..R S
string..T Z
id..[ ]
)..] ^
{// 	
Guid00 
proId00 
=00 
Guid00 
.00 
Parse00 #
(00# $
id00$ &
)00& '
;00' (
Product11 
product11 
=11 
_productService11 -
.11- .
FindById11. 6
(116 7
proId117 <
)11< =
;11= >
Log22 
.22 
Information22 
(22 
$str22 T
,22T U
id22V X
,22X Y
DateTime22Z b
.22b c
Now22c f
,22f g
product22h o
)22o p
;22p q
return33 
product33 
!=33 
null33 "
?33# $
await33% *
Task33+ /
.33/ 0

FromResult330 :
(33: ;

StatusCode33; E
(33E F
StatusCodes33F Q
.33Q R
Status200OK33R ]
,33] ^
product33_ f
)33f g
)33g h
:33i j
await44 
Task44 
.44 

FromResult44 )
(44) *

StatusCode44* 4
(444 5
StatusCodes445 @
.44@ A
Status404NotFound44A R
,44R S
new44T W
{44X Y

StatusCode44Z d
=44e f
StatusCodes44g r
.44r s 
Status400BadRequest	44s Ü
,
44Ü á
Message
44à è
=
44ê ë
$"
44í î
$str
44î °
{
44° ¢
id
44¢ §
}
44§ •
$str
44• µ
"
44µ ∂
}
44∑ ∏
)
44∏ π
)
44π ∫
;
44∫ ª
}55 	
[99 	
HttpPost99	 
(99 
$str99  
)99  !
]99! "
public:: 
async:: 
Task:: 
<:: 
IActionResult:: '
>::' (
CreateNewPro::) 5
(::5 6
[::6 7
FromBody::7 ?
]::? @
CreateProductReqDto::A T

proRequest::U _
)::_ `
{;; 	
CommonResponseDto<< 
<<< 
Product<< %
><<% &
created<<' .
=<</ 0
(<<1 2
CommonResponseDto<<2 C
<<<C D
Product<<D K
><<K L
)<<L M
await<<N S
_productService<<T c
.<<c d
CreateNewProduct<<d t
(<<t u

proRequest<<u 
)	<< Ä
;
<<Ä Å
if== 
(== 
created== 
.== 
Data== 
!=== 
null==  $
)==$ %
{>> 
created?? 
.?? 

StatusCode?? "
=??# $
StatusCodes??% 0
.??0 1
Status201Created??1 A
;??A B
Log@@ 
.@@ 
Information@@ 
(@@  
$str@@  T
,@@T U
DateTime@@V ^
.@@^ _
Now@@_ b
,@@b c
created@@d k
)@@k l
;@@l m
returnAA 
awaitAA 
TaskAA !
.AA! "

FromResultAA" ,
(AA, -

StatusCodeAA- 7
(AA7 8
StatusCodesAA8 C
.AAC D
Status201CreatedAAD T
,AAT U
newAAV Y
{BB 

StatusCodeCC 
=CC  
StatusCodesCC! ,
.CC, -
Status201CreatedCC- =
,CC= >
ResponseModelDD !
=DD" #
createdDD$ +
}EE 
)EE 
)EE 
;EE 
}FF 
elseGG 
{HH 
createdII 
.II 

StatusCodeII "
=II# $
StatusCodesII% 0
.II0 1
Status400BadRequestII1 D
;IID E
LogJJ 
.JJ 
InformationJJ 
(JJ  
$strJJ  R
,JJR S
DateTimeJJT \
.JJ\ ]
NowJJ] `
,JJ` a
createdJJb i
)JJi j
;JJj k
returnKK 
awaitKK 
TaskKK !
.KK! "

FromResultKK" ,
(KK, -

StatusCodeKK- 7
(KK7 8
StatusCodesKK8 C
.KKC D
Status404NotFoundKKD U
,KKU V
newKKW Z
{KK[ \

StatusCodeKK] g
=KKh i
StatusCodesKKj u
.KKu v 
Status400BadRequest	KKv â
,
KKâ ä
ResponseModel
KKã ò
=
KKô ö
created
KKõ ¢
}
KK£ §
)
KK§ •
)
KK• ¶
;
KK¶ ß
}LL 
}MM 	
[QQ 	
HttpPutQQ	 
(QQ 
$strQQ $
)QQ$ %
]QQ% &
publicRR 
asyncRR 
TaskRR 
<RR 
IActionResultRR '
>RR' (
UpdateProByIdRR) 6
(RR6 7
[RR7 8
	FromRouteRR8 A
(RRA B
NameRRB F
=RRG H
$strRRI P
)RRP Q
]RRQ R
stringRRS Y
idRRZ \
,RR\ ]
[RR^ _
FromBodyRR_ g
]RRg h
UpdateProductReqDtoRRi |
model	RR} Ç
)
RRÇ É
{SS 	
CommonResponseDtoTT 
<TT 
ProductTT %
>TT% &
updatedTT' .
=TT/ 0
(TT1 2
CommonResponseDtoTT2 C
<TTC D
ProductTTD K
>TTK L
)TTL M
awaitTTN S
_productServiceTTT c
.TTc d
UpdateProductTTd q
(TTq r
idTTr t
,TTt u
modelTTv {
)TT{ |
;TT| }
ifVV 
(VV 
updatedVV 
.VV 
DataVV 
!=VV 
nullVV  $
)VV$ %
{WW 
updatedXX 
.XX 

StatusCodeXX "
=XX# $
$numXX% (
;XX( )
LogYY 
.YY 
InformationYY 
(YY  
$strYY  _
,YY_ `
idYYa c
,YYc d
DateTimeYYe m
.YYm n
NowYYn q
,YYq r
updatedYYs z
)YYz {
;YY{ |
returnZZ 
awaitZZ 
TaskZZ !
.ZZ! "

FromResultZZ" ,
(ZZ, -

StatusCodeZZ- 7
(ZZ7 8
StatusCodesZZ8 C
.ZZC D
Status200OKZZD O
,ZZO P
newZZQ T
{[[ 

StatusCode\\ 
=\\  
StatusCodes\\! ,
.\\, -
Status200OK\\- 8
,\\8 9
ResponseModel]] !
=]]" #
updated]]$ +
}^^ 
)^^ 
)^^ 
;^^ 
}__ 
else`` 
{aa 
updatedbb 
.bb 

StatusCodebb "
=bb# $
StatusCodesbb% 0
.bb0 1
Status400BadRequestbb1 D
;bbD E
Logcc 
.cc 
Informationcc 
(cc  
$strcc  ^
,cc^ _
idcc` b
,ccb c
DateTimeccd l
.ccl m
Nowccm p
,ccp q
updatedccr y
)ccy z
;ccz {
returndd 
awaitdd 
Taskdd !
.dd! "

FromResultdd" ,
(dd, -

StatusCodedd- 7
(dd7 8
StatusCodesdd8 C
.ddC D
Status404NotFoundddD U
,ddU V
newddW Z
{dd[ \

StatusCodedd] g
=ddh i
StatusCodesddj u
.ddu v 
Status400BadRequest	ddv â
,
ddâ ä
ResponseModel
ddã ò
=
ddô ö
updated
ddõ ¢
}
dd£ §
)
dd§ •
)
dd• ¶
;
dd¶ ß
}ee 
}ff 	
[jj 	

HttpDeletejj	 
(jj 
$strjj (
)jj( )
]jj) *
publickk 
asynckk 
Taskkk 
<kk 
IActionResultkk '
>kk' (
	DeleteProkk) 2
(kk2 3
[kk3 4
	FromRoutekk4 =
(kk= >
Namekk> B
=kkC D
$strkkE M
)kkM N
]kkN O
stringkkP V
idkkW Y
)kkY Z
{ll 	
CommonResponseDtomm 
<mm 
Productmm %
>mm% &
deletedmm' .
=mm/ 0
(mm1 2
CommonResponseDtomm2 C
<mmC D
ProductmmD K
>mmK L
)mmL M
awaitmmM R
_productServicemmS b
.mmb c
DeleteProductmmc p
(mmp q
idmmq s
)mms t
;mmt u
ifoo 
(oo 
deletedoo 
.oo 

StatusCodeoo "
==oo# %
StatusCodesoo& 1
.oo1 2
Status200OKoo2 =
)oo= >
{pp 
Logqq 
.qq 
Informationqq 
(qq  
$strqq  S
,qqS T
idqqU W
,qqW X
DateTimeqqY a
.qqa b
Nowqqb e
)qqe f
;qqf g
returnrr 
awaitrr 
Taskrr !
.rr! "

FromResultrr" ,
(rr, -

StatusCoderr- 7
(rr7 8
StatusCodesrr8 C
.rrC D
Status200OKrrD O
,rrO P
newrrQ T
{ss 

StatusCodett 
=tt  
StatusCodestt! ,
.tt, -
Status200OKtt- 8
,tt8 9
ResponseModeluu !
=uu" #
deleteduu$ +
}vv 
)vv 
)vv 
;vv 
}ww 
elsexx 
{yy 
deletedzz 
.zz 

StatusCodezz "
=zz# $
StatusCodeszz% 0
.zz0 1
Status400BadRequestzz1 D
;zzD E
Log{{ 
.{{ 
Information{{ 
({{  
$str{{  R
,{{R S
id{{T V
,{{V W
DateTime{{X `
.{{` a
Now{{a d
){{d e
;{{e f
return|| 
await|| 
Task|| !
.||! "

FromResult||" ,
(||, -

StatusCode||- 7
(||7 8
StatusCodes||8 C
.||C D
Status400BadRequest||D W
,||W X
new||Y \
{||] ^

StatusCode||_ i
=||j k
StatusCodes||l w
.||w x 
Status400BadRequest	||x ã
,
||ã å
ResponseModel
||ç ö
=
||õ ú
deleted
||ù §
}
||• ¶
)
||¶ ß
)
||ß ®
;
||® ©
}}} 
}~~ 	
[
ÇÇ 	
HttpGet
ÇÇ	 
(
ÇÇ 
$str
ÇÇ $
)
ÇÇ$ %
]
ÇÇ% &
public
ÉÉ 
async
ÉÉ 
Task
ÉÉ 
<
ÉÉ 
IActionResult
ÉÉ '
>
ÉÉ' (
GetAllProInclude
ÉÉ) 9
(
ÉÉ9 :
)
ÉÉ: ;
{
ÑÑ 	
var
ÖÖ 
products
ÖÖ 
=
ÖÖ 
_productService
ÖÖ *
.
ÖÖ* +)
GetAllProductsWithSubObject
ÖÖ+ F
(
ÖÖF G
)
ÖÖG H
;
ÖÖH I
return
ÜÜ 
await
ÜÜ 
Task
ÜÜ 
.
ÜÜ 

FromResult
ÜÜ (
(
ÜÜ( )

StatusCode
ÜÜ) 3
(
ÜÜ3 4
StatusCodes
ÜÜ4 ?
.
ÜÜ? @
Status200OK
ÜÜ@ K
,
ÜÜK L
products
ÜÜM U
)
ÜÜU V
)
ÜÜV W
;
ÜÜW X
}
áá 	
}
ää 
}ãã ùi
íD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01\Controllers\ProductBrandController.cs
	namespace 	
PracNet7ApiProB01
 
. 
Controllers '
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class "
ProductBrandController '
:( )
ControllerBase* 8
{ 
private 
readonly 
IUnitOfWork $
_iUnitOfWork% 1
;1 2
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
private 
readonly 
IGenericRepository +
<+ ,
ProductBrand, 8
>8 9
_productBrandRepo: K
;K L
private 
readonly  
IProductBrandService - 
_productBrandService. B
;B C
public "
ProductBrandController %
(% &
IUnitOfWork& 1
_iUnitOfWork2 >
,> ? 
PracNet7ApiDbContext@ T
_contextU ]
)] ^
{ 	
this 
. 
_iUnitOfWork 
= 
_iUnitOfWork  ,
;, -
this 
. 
_context 
= 
_context $
;$ %
this 
. 
_productBrandRepo "
=# $
new% ("
ProductBrandRepository) ?
(? @
_context@ H
)H I
;I J
this 
.  
_productBrandService %
=& '
new( +
ProductBrandService, ?
(? @
_context@ H
,H I
_iUnitOfWorkJ V
,V W
_productBrandRepoW h
)h i
;i j
} 	
["" 	
HttpGet""	 
("" 
$str"" "
)""" #
]""# $
public## 
async## 
Task## 
<## 
IActionResult## '
>##' (
GetAllProBrands##) 8
(##8 9
)##9 :
{$$ 	
List%% 
<%% 
ProductBrand%% 
>%% 
productBrands%% ,
=%%- . 
_productBrandService%%/ C
.%%C D
FindAll%%D K
(%%K L
)%%L M
;%%M N
Log&& 
.&& 
Information&& 
(&& 
$str&& O
,&&O P
DateTime&&Q Y
.&&Y Z
Now&&Z ]
,&&] ^
productBrands&&_ l
)&&l m
;&&m n
return(( 
await(( 
Task(( 
.(( 

FromResult(( (
(((( )

StatusCode(() 3
(((3 4
StatusCodes((4 ?
.((? @
Status200OK((@ K
,((K L
productBrands((M Z
)((Z [
)(([ \
;((\ ]
})) 	
[-- 	
HttpGet--	 
(-- 
$str-- /
)--/ 0
]--0 1
public.. 
async.. 
Task.. 
<.. 
IActionResult.. '
>..' (
GetGenRoleById..) 7
(..7 8
[..8 9
	FromRoute..9 B
(..B C
Name..C G
=..H I
$str..J V
)..V W
]..W X
string..Y _
id..` b
)..b c
{// 	
Guid00 

proBrandId00 
=00 
Guid00 "
.00" #
Parse00# (
(00( )
id00) +
)00+ ,
;00, -
ProductBrand11 
productBrand11 %
=11& ' 
_productBrandService11( <
.11< =
FindById11= E
(11E F

proBrandId11F P
)11P Q
;11Q R
Log22 
.22 
Information22 
(22 
$str22 X
,22X Y
id22Z \
,22\ ]
DateTime22^ f
.22f g
Now22g j
,22j k
productBrand22l x
)22x y
;22y z
return33 
productBrand33 
!=33  "
null33# '
?33( )
await33* /
Task330 4
.334 5

FromResult335 ?
(33? @

StatusCode33@ J
(33J K
StatusCodes33K V
.33V W
Status200OK33W b
,33b c
productBrand33d p
)33p q
)33q r
:33s t
await44 
Task44 
.44 

FromResult44 )
(44) *

StatusCode44* 4
(444 5
StatusCodes445 @
.44@ A
Status404NotFound44A R
,44R S
new44T W
{44X Y

StatusCode44Z d
=44e f
StatusCodes44g r
.44r s 
Status400BadRequest	44s Ü
,
44Ü á
Message
44à è
=
44ê ë
$"
44í î
$str
44î ß
{
44ß ®
id
44® ™
}
44™ ´
$str
44´ ª
"
44ª º
}
44Ω æ
)
44æ ø
)
44ø ¿
;
44¿ ¡
}55 	
[:: 	
HttpPost::	 
(:: 
$str:: %
)::% &
]::& '
public;; 
async;; 
Task;; 
<;; 
IActionResult;; '
>;;' (
CreateNewProBrand;;) :
(;;: ;
[;;; <
FromBody;;< D
];;D E$
CreateProductBrandReqDto;;F ^
proBrandRequest;;_ n
);;n o
{<< 	
CommonResponseDto>> 
<>> 
ProductBrand>> *
>>>* +
created>>, 3
=>>4 5
(>>6 7
CommonResponseDto>>7 H
<>>H I
ProductBrand>>I U
>>>U V
)>>V W
await>>W \ 
_productBrandService>>] q
.>>q r"
CreateNewProductBrand	>>r á
(
>>á à
proBrandRequest
>>à ó
)
>>ó ò
;
>>ò ô
Console?? 
.?? 
	WriteLine?? 
(?? 
created?? %
)??% &
;??& '
if@@ 
(@@ 
created@@ 
.@@ 
Data@@ 
!=@@ 
null@@  $
)@@$ %
{AA 
createdBB 
.BB 

StatusCodeBB "
=BB# $
StatusCodesBB% 0
.BB0 1
Status201CreatedBB1 A
;BBA B
LogCC 
.CC 
InformationCC 
(CC  
$strCC  M
,CCM N
DateTimeCCO W
.CCW X
NowCCX [
,CC[ \
createdCC] d
)CCd e
;CCe f
returnDD 
awaitDD 
TaskDD !
.DD! "

FromResultDD" ,
(DD, -

StatusCodeDD- 7
(DD7 8
StatusCodesDD8 C
.DDC D
Status201CreatedDDD T
,DDT U
newDDV Y
{EE 

StatusCodeFF 
=FF  
StatusCodesFF! ,
.FF, -
Status201CreatedFF- =
,FF= >
ResponseModelGG !
=GG" #
createdGG$ +
,GG+ ,
}HH 
)HH 
)HH 
;HH 
}II 
elseJJ 
{KK 
createdLL 
.LL 

StatusCodeLL "
=LL# $
StatusCodesLL% 0
.LL0 1
Status400BadRequestLL1 D
;LLD E
returnMM 
awaitMM 
TaskMM !
.MM! "

FromResultMM" ,
(MM, -

StatusCodeMM- 7
(MM7 8
StatusCodesMM8 C
.MMC D
Status404NotFoundMMD U
,MMU V
newMMW Z
{MM[ \

StatusCodeMM] g
=MMh i
StatusCodesMMj u
.MMu v 
Status400BadRequest	MMv â
,
MMâ ä
ResponseModel
MMã ò
=
MMô ö
created
MMõ ¢
}
MM£ §
)
MM§ •
)
MM• ¶
;
MM¶ ß
}NN 
}OO 	
[UU 	
HttpPutUU	 
(UU 
$strUU .
)UU. /
]UU/ 0
publicVV 
asyncVV 
TaskVV 
<VV 
IActionResultVV '
>VV' (
UpdateGenCodeByIdVV) :
(VV: ;
[VV; <
	FromRouteVV< E
(VVE F
NameVVF J
=VVK L
$strVVM Y
)VVY Z
]VVZ [
stringVV\ b
idVVc e
,VVe f
[VVg h
FromBodyVVh p
]VVp q%
UpdateProductBrandReqDto	VVr ä
model
VVã ê
)
VVê ë
{WW 	
CommonResponseDtoXX 
<XX 
ProductBrandXX *
>XX* +
updatedXX, 3
=XX4 5
(XX6 7
CommonResponseDtoXX7 H
<XXH I
ProductBrandXXI U
>XXU V
)XXV W
awaitXXW \ 
_productBrandServiceXX] q
.XXq r
UpdateProductBrand	XXr Ñ
(
XXÑ Ö
id
XXÖ á
,
XXá à
model
XXâ é
)
XXé è
;
XXè ê
ifZZ 
(ZZ 
updatedZZ 
.ZZ 
DataZZ 
!=ZZ 
nullZZ  $
)ZZ$ %
{[[ 
updated\\ 
.\\ 

StatusCode\\ "
=\\# $
$num\\% (
;\\( )
Log]] 
.]] 
Information]] 
(]]  
$str]]  _
,]]_ `
id]]a c
,]]c d
DateTime]]e m
.]]m n
Now]]n q
,]]q r
updated]]s z
)]]z {
;]]{ |
return^^ 
await^^ 
Task^^ !
.^^! "

FromResult^^" ,
(^^, -

StatusCode^^- 7
(^^7 8
StatusCodes^^8 C
.^^C D
Status200OK^^D O
,^^O P
new^^Q T
{__ 

StatusCode`` 
=``  
StatusCodes``! ,
.``, -
Status200OK``- 8
,``8 9
ResponseModelaa !
=aa" #
updatedaa$ +
}bb 
)bb 
)bb 
;bb 
}cc 
elsedd 
{ee 
updatedff 
.ff 

StatusCodeff "
=ff# $
StatusCodesff% 0
.ff0 1
Status400BadRequestff1 D
;ffD E
returngg 
awaitgg 
Taskgg !
.gg! "

FromResultgg" ,
(gg, -

StatusCodegg- 7
(gg7 8
StatusCodesgg8 C
.ggC D
Status400BadRequestggD W
,ggW X
newggY \
{gg] ^

StatusCodegg_ i
=ggj k
StatusCodesggl w
.ggw x 
Status400BadRequest	ggx ã
,
ggã å
ResponseModel
ggç ö
=
ggõ ú
updated
ggù §
}
gg• ¶
)
gg¶ ß
)
ggß ®
;
gg® ©
}hh 
}jj 	
[oo 	

HttpDeleteoo	 
(oo 
$stroo 1
)oo1 2
]oo2 3
publicpp 
asyncpp 
Taskpp 
<pp 
IActionResultpp '
>pp' (
DeleteProBrandpp) 7
(pp7 8
[pp8 9
	FromRoutepp9 B
(ppB C
NameppC G
=ppH I
$strppJ V
)ppV W
]ppW X
stringppY _
idpp` b
)ppb c
{qq 	
CommonResponseDtorr 
<rr 
ProductBrandrr *
>rr* +
deletedrr, 3
=rr4 5
(rr6 7
CommonResponseDtorr7 H
<rrH I
ProductBrandrrI U
>rrU V
)rrV W
awaitrrW \ 
_productBrandServicerr] q
.rrq r
DeleteProductBrand	rrr Ñ
(
rrÑ Ö
id
rrÖ á
)
rrá à
;
rrà â
iftt 
(tt 
deletedtt 
.tt 

StatusCodett "
==tt# %
StatusCodestt& 1
.tt1 2
Status200OKtt2 =
)tt= >
{uu 
Logvv 
.vv 
Informationvv 
(vv  
$strvv  X
,vvX Y
idvvZ \
,vv\ ]
DateTimevv^ f
.vvf g
Nowvvg j
)vvj k
;vvk l
returnww 
awaitww 
Taskww !
.ww! "

FromResultww" ,
(ww, -

StatusCodeww- 7
(ww7 8
StatusCodesww8 C
.wwC D
Status200OKwwD O
,wwO P
newwwQ T
{xx 

StatusCodeyy 
=yy  
StatusCodesyy! ,
.yy, -
Status200OKyy- 8
,yy8 9
ResponseModelzz !
=zz" #
deletedzz$ +
}{{ 
){{ 
){{ 
;{{ 
}|| 
else}} 
{~~ 
deleted 
. 

StatusCode "
=# $
StatusCodes% 0
.0 1
Status400BadRequest1 D
;D E
return
ÄÄ 
await
ÄÄ 
Task
ÄÄ !
.
ÄÄ! "

FromResult
ÄÄ" ,
(
ÄÄ, -

StatusCode
ÄÄ- 7
(
ÄÄ7 8
StatusCodes
ÄÄ8 C
.
ÄÄC D!
Status400BadRequest
ÄÄD W
,
ÄÄW X
new
ÄÄY \
{
ÄÄ] ^

StatusCode
ÄÄ_ i
=
ÄÄj k
StatusCodes
ÄÄl w
.
ÄÄw x"
Status400BadRequestÄÄx ã
,ÄÄã å
ResponseModelÄÄç ö
=ÄÄõ ú
deletedÄÄù §
}ÄÄ• ¶
)ÄÄ¶ ß
)ÄÄß ®
;ÄÄ® ©
}
ÅÅ 
}
ÇÇ 	
}
ÑÑ 
}ÖÖ Ü]
ëD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01\Controllers\GeneralRoleController.cs
	namespace

 	
PracNet7ApiProB01


 
.

 
Controllers

 '
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class !
GeneralRoleController &
:& '
ControllerBase( 6
{ 
private 
readonly 
IUnitOfWork $
_iUnitOfWork% 1
;1 2
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
private 
readonly 
IGenericRepository +
<+ ,
GeneralRole, 7
>7 8
_genRepo9 A
;A B
private 
readonly 
IGeneralRoleService ,
_genRoleService- <
;< =
public !
GeneralRoleController $
($ %
IUnitOfWork% 0
_iUnitOfWork1 =
,= > 
PracNet7ApiDbContext? S
_contextT \
)\ ]
{ 	
this 
. 
_iUnitOfWork 
= 
_iUnitOfWork  ,
;, -
this 
. 
_context 
= 
_context $
;$ %
_genRepo 
= 
new !
GeneralRoleRepository 0
(0 1
_context1 9
)9 :
;: ;
this 
. 
_genRoleService  
=! "
new# &
GeneralRoleService' 9
(9 :
this: >
.> ?
_context? G
,G H
thisI M
.M N
_iUnitOfWorkN Z
,Z [
this\ `
.` a
_genRepoa i
)i j
;j k
} 	
[ 	
HttpGet	 
( 
$str !
)! "
]" #
public   
async   
Task   
<   
IActionResult   '
>  ' (
GetAllGenRoles  ) 7
(  7 8
)  8 9
{!! 	
List"" 
<"" 
GeneralRole"" 
>"" 
generalRoles"" *
=""+ ,
_genRoleService""- <
.""< =
FindAll""= D
(""D E
)""E F
;""F G
return## 
await## 
Task## 
.## 

FromResult## (
(##( )

StatusCode##) 3
(##3 4
StatusCodes##4 ?
.##? @
Status200OK##@ K
,##K L
generalRoles##M Y
)##Y Z
)##Z [
;##[ \
}$$ 	
[(( 	
HttpGet((	 
((( 
$str(( -
)((- .
]((. /
public)) 
async)) 
Task)) 
<)) 
IActionResult)) '
>))' (
GetGenRoleById))) 7
())7 8
[))8 9
	FromRoute))9 B
())B C
Name))C G
=))H I
$str))J U
)))U V
]))V W
string))X ^
id))_ a
)))a b
{** 	
Guid++ 
	genRoleId++ 
=++ 
Guid++ !
.++! "
Parse++" '
(++' (
id++( *
)++* +
;+++ ,
GeneralRole,, 
generalRole,, #
=,,$ %
_genRoleService,,& 5
.,,5 6
FindById,,6 >
(,,> ?
	genRoleId,,? H
),,H I
;,,I J
return-- 
generalRole-- 
!=-- !
null--" &
?--' (
await--) .
Task--/ 3
.--3 4

FromResult--4 >
(--> ?

StatusCode--? I
(--I J
StatusCodes--J U
.--U V
Status200OK--V a
,--a b
generalRole--c n
)--n o
)--o p
:--q r
await.. 
Task.. 
... 

FromResult.. )
(..) *

StatusCode..* 4
(..4 5
StatusCodes..5 @
...@ A
Status404NotFound..A R
,..R S
new..T W
{..X Y

StatusCode..Z d
=..e f
StatusCodes..g r
...r s 
Status400BadRequest	..s Ü
,
..Ü á
Message
..à è
=
..ê ë
$"
..í î
$str
..î ¶
{
..¶ ß
id
..ß ©
}
..© ™
$str
..™ ∫
"
..∫ ª
}
..º Ω
)
..Ω æ
)
..æ ø
;
..ø ¿
}// 	
[44 	
HttpPost44	 
(44 
$str44 $
)44$ %
]44% &
public55 
async55 
Task55 
<55 
IActionResult55 '
>55' (
CreateNewGenRole55) 9
(559 :
[55: ;
FromBody55; C
]55C D#
CreateGeneralRoleReqDro55E \
generalRoleRequest55] o
)55o p
{66 	
CommonResponseDto88 
<88 
GeneralRole88 )
>88) *
created88+ 2
=883 4
(885 6
CommonResponseDto886 G
<88G H
GeneralRole88H S
>88S T
)88T U
await88U Z
_genRoleService88[ j
.88j k
CreateNewGenRole88k {
(88{ |
generalRoleRequest	88| é
)
88é è
;
88è ê
if99 
(99 
created99 
.99 
Data99 
!=99 
null99  $
)99$ %
{:: 
created;; 
.;; 

StatusCode;; "
=;;# $
StatusCodes;;% 0
.;;0 1
Status201Created;;1 A
;;;A B
return<< 
await<< 
Task<< !
.<<! "

FromResult<<" ,
(<<, -

StatusCode<<- 7
(<<7 8
StatusCodes<<8 C
.<<C D
Status201Created<<D T
,<<T U
new<<V Y
{== 

StatusCode>> 
=>>  
StatusCodes>>! ,
.>>, -
Status201Created>>- =
,>>= >
ResponseModel?? !
=??" #
created??$ +
}@@ 
)@@ 
)@@ 
;@@ 
}AA 
elseBB 
{CC 
createdDD 
.DD 

StatusCodeDD "
=DD# $
StatusCodesDD% 0
.DD0 1
Status400BadRequestDD1 D
;DDD E
returnEE 
awaitEE 
TaskEE !
.EE! "

FromResultEE" ,
(EE, -

StatusCodeEE- 7
(EE7 8
StatusCodesEE8 C
.EEC D
Status404NotFoundEED U
,EEU V
newEEW Z
{EE[ \

StatusCodeEE] g
=EEh i
StatusCodesEEj u
.EEu v 
Status400BadRequest	EEv â
,
EEâ ä
ResponseModel
EEã ò
=
EEô ö
created
EEõ ¢
}
EE£ §
)
EE§ •
)
EE• ¶
;
EE¶ ß
}FF 
}GG 	
[MM 
HttpPutMM 
(MM 
$strMM 0
)MM0 1
]MM1 2
publicNN 
asyncNN 
TaskNN 
<NN 
IActionResultNN '
>NN' (
UpdateGenCodeByIdNN) :
(NN: ;
[NN; <
	FromRouteNN< E
(NNE F
NameNNF J
=NNK L
$strNNN Y
)NNY Z
]NNZ [
stringNN\ b
idNNc e
,NNe f
[NNg h
FromBodyNNh p
]NNp q 
UpdateGenRoleReqDto	NNr Ö
model
NNÜ ã
)
NNã å
{OO 	
CommonResponseDtoPP 
<PP 
GeneralRolePP )
>PP) *
updatedPP+ 2
=PP3 4
(PP5 6
CommonResponseDtoPP6 G
<PPG H
GeneralRolePPH S
>PPS T
)PPT U
awaitPPV [
_genRoleServicePP\ k
.PPk l
UpdateGenRolePPl y
(PPy z
idPPz |
,PP| }
model	PP~ É
)
PPÉ Ñ
;
PPÑ Ö
ifRR 
(RR 
updatedRR 
.RR 
DataRR 
!=RR 
nullRR  $
)RR$ %
{SS 
returnTT 
awaitTT 
TaskTT !
.TT! "

FromResultTT" ,
(TT, -

StatusCodeTT- 7
(TT7 8
StatusCodesTT8 C
.TTC D
Status200OKTTD O
,TTO P
newTTQ T
{UU 

StatusCodeVV 
=VV  
StatusCodesVV! ,
.VV, -
Status201CreatedVV- =
,VV= >
ResponseModelWW !
=WW" #
updatedWW$ +
}XX 
)XX 
)XX 
;XX 
}YY 
elseZZ 
{[[ 
updated\\ 
.\\ 

StatusCode\\ "
=\\# $
StatusCodes\\% 0
.\\0 1
Status400BadRequest\\1 D
;\\D E
return]] 
await]] 
Task]] !
.]]! "

FromResult]]" ,
(]], -

StatusCode]]- 7
(]]7 8
StatusCodes]]8 C
.]]C D
Status404NotFound]]D U
,]]U V
new]]W Z
{]][ \

StatusCode]]] g
=]]h i
StatusCodes]]j u
.]]u v 
Status400BadRequest	]]v â
,
]]â ä
ResponseModel
]]ã ò
=
]]ô ö
updated
]]õ ¢
}
]]£ §
)
]]§ •
)
]]• ¶
;
]]¶ ß
}^^ 
}`` 	
[ee 	

HttpDeleteee	 
(ee 
$stree /
)ee/ 0
]ee0 1
publicff 
asyncff 
Taskff 
<ff 
IActionResultff '
>ff' (
DeleteGenRoleff) 6
(ff6 7
[ff7 8
	FromRouteff8 A
(ffA B
NameffB F
=ffG H
$strffI T
)ffT U
]ffU V
stringffW ]
idff^ `
)ff` a
{gg 	
CommonResponseDtohh 
<hh 
GeneralRolehh )
>hh) *
deletedhh+ 2
=hh3 4
(hh5 6
CommonResponseDtohh6 G
<hhH I
GeneralRolehhJ U
>hhV W
)hhW X
awaithhY ^
_genRoleServicehh_ n
.hhn o
DeleteGenRolehho |
(hh| }
idhh} 
)	hh Ä
;
hhÄ Å
ifpp 
(pp 
deletedpp 
.pp 

StatusCodepp "
==pp# %
StatusCodespp& 1
.pp1 2
Status200OKpp2 =
)pp= >
{qq 
returnrr 
awaitrr 
Taskrr !
.rr! "

FromResultrr" ,
(rr, -

StatusCoderr- 7
(rr7 8
StatusCodesrr8 C
.rrC D
Status200OKrrD O
,rrO P
newrrQ T
{ss 

StatusCodett 
=tt  
StatusCodestt! ,
.tt, -
Status200OKtt- 8
,tt8 9
Messageuu 
=uu 
$struu E
}vv 
)vv 
)vv 
;vv 
}ww 
elsexx 
{yy 
deletedzz 
.zz 

StatusCodezz "
=zz# $
StatusCodeszz% 0
.zz0 1
Status400BadRequestzz1 D
;zzD E
return{{ 
await{{ 
Task{{ !
.{{! "

FromResult{{" ,
({{, -

StatusCode{{- 7
({{7 8
StatusCodes{{8 C
.{{C D
Status400BadRequest{{D W
,{{W X
new{{Y \
{{{] ^

StatusCode{{_ i
={{j k
StatusCodes{{l w
.{{w x 
Status400BadRequest	{{x ã
,
{{ã å
ResponseModel
{{ç ö
=
{{õ ú
deleted
{{ù §
}
{{• ¶
)
{{¶ ß
)
{{ß ®
;
{{® ©
}|| 
}}} 	
}
ÄÄ 
}ÅÅ Â%
äD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01\Controllers\BaseController.cs
	namespace 	
PracNet7ApiProB01
 
. 
Controllers '
{ 
[ 
Route 

(
 
$str 
) 
] 
[		 
ApiController		 
]		 
public

 

class

 
BaseController

 
<

  
TEntity

  '
>

' (
:

) *
ControllerBase

+ 9
where

: ?
TEntity

@ G
:

H I
class

J O
{ 
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
private 
readonly 
IGenericRepository +
<+ ,
TEntity, 3
>3 4
_repository5 @
;@ A
private 
readonly 
IGenericService (
<( )
TEntity) 0
>0 1
_service2 :
;: ;
public 
BaseController 
( 
IUnitOfWork )

unitOfWork* 4
,4 5 
PracNet7ApiDbContext6 J
contextK R
,R S
IGenericRepositoryT f
<f g
TEntityg n
>n o

repositoryp z
,z {
IGenericService	| ã
<
ã å
TEntity
å ì
>
ì î
service
ï ú
)
ú ù
{ 	
_unitOfWork 
= 

unitOfWork $
;$ %
_context 
= 
context 
; 
_repository 
= 

repository $
;$ %
_service 
= 
service 
; 
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
GetAllItems) 4
(4 5
)5 6
{ 	
List 
< 
TEntity 
> 
listAllItems &
=' (
_service) 1
.1 2
FindAll2 9
(9 :
): ;
;; <
return 
await 
Task 
. 

FromResult (
(( )

StatusCode) 3
(3 4
StatusCodes4 ?
.? @
Status200OK@ K
,K L
listAllItemsM Y
)Y Z
)Z [
;[ \
} 	
[$$ 	
HttpGet$$	 
($$ 
$str$$ 
)$$  
]$$  !
public%% 
async%% 
Task%% 
<%% 
IActionResult%% '
>%%' (
GetItemById%%) 4
(%%4 5
[%%5 6
	FromRoute%%6 ?
(%%? @
Name%%@ D
=%%E F
$str%%G K
)%%K L
]%%L M
string%%N T
id%%U W
)%%W X
{&& 	
Guid'' 
uuid'' 
='' 
Guid'' 
.'' 
Parse'' "
(''" #
id''# %
)''% &
;''& '
TEntity(( 
item(( 
=(( 
_service(( #
.((# $
FindById(($ ,
(((, -
uuid((- 1
)((1 2
;((2 3
string)) 

entityName)) 
=)) 
typeof))  &
())& '
TEntity))' .
))). /
.))/ 0
Name))0 4
;))4 5
return** 
item** 
!=** 
null** 
?**  !
await**" '
Task**( ,
.**, -

FromResult**- 7
(**7 8

StatusCode**8 B
(**B C
StatusCodes**C N
.**N O
Status200OK**O Z
,**Z [
item**\ `
)**` a
)**a b
:**c d
await++ 
Task++ 
.++ 

FromResult++ )
(++) *

StatusCode++* 4
(++4 5
StatusCodes++5 @
.++@ A
Status404NotFound++A R
,++R S
new++T W
{++X Y

StatusCode++Z d
=++e f
StatusCodes++g r
.++r s 
Status400BadRequest	++s Ü
,
++Ü á
Message
++à è
=
++ê ë
$"
++í î
{
++î ï

entityName
++ï ü
}
++ü †
$str
++† ¶
{
++¶ ß
id
++ß ©
}
++© ™
$str
++™ ∫
"
++∫ ª
}
++º Ω
)
++Ω æ
)
++æ ø
;
++ø ¿
},, 	
}// 
}00 
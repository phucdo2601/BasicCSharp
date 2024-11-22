À
™D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\StaffRoleRepository\StaffRoleRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /
StaffRoleRepository		/ B
{

 
public 

class 
StaffRoleRepository $
:% &
GenericRepository' 8
<8 9
	StaffRole9 B
>B C
,C D 
IStaffRoleRepositoryE Y
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
public 
StaffRoleRepository "
(" # 
PracNet7ApiDbContext# 7
_context8 @
)@ A
:B C
baseD H
(H I
_contextI Q
)Q R
{ 	
this 
. 
_context 
= 
_context $
;$ %
} 	
} 
} ∆
´D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\StaffRoleRepository\IStaffRoleRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /
StaffRoleRepository		/ B
{

 
public 

	interface  
IStaffRoleRepository )
:* +
IGenericRepository, >
<> ?
	StaffRole? H
>H I
{ 
} 
} Ø
¢D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\StaffRepository\StaffRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /
StaffRepository		/ >
{

 
public 

class 
StaffRepository  
:! "
GenericRepository# 4
<4 5
Staff5 :
>: ;
,; <
IStaffRepository= M
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
public 
StaffRepository 
(  
PracNet7ApiDbContext 3
_context4 <
)< =
:> ?
base@ D
(D E
_contextE M
)M N
{ 	
this 
. 
_context 
= 
_context $
;$ %
} 	
} 
} ≤
£D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\StaffRepository\IStaffRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /
StaffRepository		/ >
{

 
public 

	interface 
IStaffRepository %
:& '
IGenericRepository( :
<: ;
Staff; @
>@ A
{ 
} 
} Ω
¶D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\ProductRepository\ProductRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /
ProductRepository		/ @
{

 
public 

class 
ProductRepository "
:# $
GenericRepository% 6
<6 7
Product7 >
>> ?
,? @
IProductRepositoryA S
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
public 
ProductRepository  
(  ! 
PracNet7ApiDbContext! 5
_context6 >
)> ?
:@ A
baseB F
(F G
_contextG O
)O P
{ 	
this 
. 
_context 
= 
_context $
;$ %
} 	
} 
} º
ßD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\ProductRepository\IProductRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /
ProductRepository		/ @
{

 
public 

	interface 
IProductRepository '
:( )
IGenericRepository* <
<< =
Product= D
>D E
{ 
} 
} ‡
∞D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\ProductBrandRepository\ProductBrandRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /"
ProductBrandRepository		/ E
{

 
public 

class "
ProductBrandRepository '
:( )
GenericRepository* ;
<; <
ProductBrand< H
>H I
,I J#
IProductBrandRepositoryK b
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
public "
ProductBrandRepository %
(% & 
PracNet7ApiDbContext& :
_context; C
)C D
:E F
baseG K
(K L
_contextL T
)T U
{ 	
this 
. 
_context 
= 
_context $
;$ %
} 	
} 
} ’
±D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\ProductBrandRepository\IProductBrandRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /"
ProductBrandRepository		/ E
{

 
public 

	interface #
IProductBrandRepository ,
:- .
IGenericRepository/ A
<A B
ProductBrandB N
>N O
{ 
} 
} ‰
∑D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\GeneralUserInfoRepository\IGeneralUserInfoRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /%
GeneralUserInfoRepository		/ H
{

 
public 

	interface &
IGeneralUserInfoRepository /
:0 1
IGenericRepository2 D
<D E
GeneralUserInfoE T
>T U
{ 
} 
} ı
∂D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\GeneralUserInfoRepository\GeneralUserInfoRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /%
GeneralUserInfoRepository		/ H
{

 
public 

class %
GeneralUserInfoRepository *
:+ ,
GenericRepository- >
<> ?
GeneralUserInfo? N
>N O
,O P&
IGeneralUserInfoRepositoryQ k
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
public %
GeneralUserInfoRepository (
(( ) 
PracNet7ApiDbContext) =
_context> F
)F G
:H I
baseJ N
(N O
_contextO W
)W X
{ 	
this 
. 
_context 
= 
_context $
;$ %
} 	
} 
} Ÿ
ÆD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\GeneralRoleRepository\GeneralRoleRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /!
GeneralRoleRepository		/ D
{

 
public 

class !
GeneralRoleRepository &
:' (
GenericRepository) :
<: ;
GeneralRole; F
>F G
,G H"
IGeneralRoleRepositoryI _
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
public !
GeneralRoleRepository $
($ % 
PracNet7ApiDbContext% 9
_context: B
)B C
:D E
baseF J
(J K
_contextK S
)S T
{ 	
this 
. 
_context 
= 
_context $
;$ %
} 	
} 
} –
ØD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\GeneralRoleRepository\IGeneralRoleRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /!
GeneralRoleRepository		/ D
{

 
public 

	interface "
IGeneralRoleRepository +
:, -
IGenericRepository. @
<@ A
GeneralRoleA L
>L M
{ 
} 
} ¡
©D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\CustomerRepository\ICustomerRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /
CustomerRepository		/ A
{

 
public 

	interface 
ICustomerRepository (
:) *
IGenericRepository+ =
<= >
Customer> F
>F G
{ 
} 
} ƒ
®D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Repositories\CustomerRepository\CustomerRepository.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Repositories		" .
.		. /
CustomerRepository		/ A
{

 
public 

class 
CustomerRepository #
:$ %
GenericRepository& 7
<7 8
Customer8 @
>@ A
,A B
ICustomerRepositoryC V
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
public 
CustomerRepository !
(! " 
PracNet7ApiDbContext" 6
_context7 ?
)? @
:A B
baseC G
(G H
_contextH P
)P Q
{ 	
this 
. 
_context 
= 
_context $
;$ %
} 	
} 
} ∫s
´D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Migrations\20240713084528_Update-Db-product-model-b01.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "

Migrations" ,
{ 
public		 

partial		 
class		 #
UpdateDbproductmodelb01		 0
:		1 2
	Migration		3 <
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
AlterColumn (
<( )
DateTime) 1
>1 2
(2 3
name 
: 
$str $
,$ %
table 
: 
$str %
,% &
type 
: 
$str 3
,3 4
nullable 
: 
true 
, 

oldClrType 
: 
typeof "
(" #
DateTime# +
)+ ,
,, -
oldType 
: 
$str 3
,3 4
oldNullable 
: 
true !
)! "
;" #
migrationBuilder 
. 
AlterColumn (
<( )
DateTime) 1
>1 2
(2 3
name 
: 
$str $
,$ %
table 
: 
$str %
,% &
type 
: 
$str 3
,3 4
nullable 
: 
true 
, 

oldClrType 
: 
typeof "
(" #
DateTime# +
)+ ,
,, -
oldType 
: 
$str 3
,3 4
oldNullable 
: 
true !
)! "
;" #
migrationBuilder   
.   
AlterColumn   (
<  ( )
string  ) /
>  / 0
(  0 1
name!! 
:!! 
$str!! #
,!!# $
table"" 
:"" 
$str""  
,""  !
type## 
:## 
$str## 
,## 
nullable$$ 
:$$ 
false$$ 
,$$  

oldClrType%% 
:%% 
typeof%% "
(%%" #
float%%# (
)%%( )
,%%) *
oldType&& 
:&& 
$str&& 
)&&  
;&&  !
migrationBuilder(( 
.(( 
AlterColumn(( (
<((( )
string(() /
>((/ 0
(((0 1
name)) 
:)) 
$str)) #
,))# $
table** 
:** 
$str**  
,**  !
type++ 
:++ 
$str++ 
,++ 
nullable,, 
:,, 
false,, 
,,,  

oldClrType-- 
:-- 
typeof-- "
(--" #
float--# (
)--( )
,--) *
oldType.. 
:.. 
$str.. 
)..  
;..  !
migrationBuilder00 
.00 
AlterColumn00 (
<00( )
DateTime00) 1
>001 2
(002 3
name11 
:11 
$str11 $
,11$ %
table22 
:22 
$str22  
,22  !
type33 
:33 
$str33 3
,333 4
nullable44 
:44 
true44 
,44 

oldClrType55 
:55 
typeof55 "
(55" #
DateTime55# +
)55+ ,
,55, -
oldType66 
:66 
$str66 3
,663 4
oldNullable77 
:77 
true77 !
)77! "
;77" #
migrationBuilder99 
.99 
AlterColumn99 (
<99( )
DateTime99) 1
>991 2
(992 3
name:: 
::: 
$str:: $
,::$ %
table;; 
:;; 
$str;;  
,;;  !
type<< 
:<< 
$str<< 3
,<<3 4
nullable== 
:== 
true== 
,== 

oldClrType>> 
:>> 
typeof>> "
(>>" #
DateTime>># +
)>>+ ,
,>>, -
oldType?? 
:?? 
$str?? 3
,??3 4
oldNullable@@ 
:@@ 
true@@ !
)@@! "
;@@" #
migrationBuilderBB 
.BB 
AlterColumnBB (
<BB( )
DateTimeBB) 1
>BB1 2
(BB2 3
nameCC 
:CC 
$strCC $
,CC$ %
tableDD 
:DD 
$strDD .
,DD. /
typeEE 
:EE 
$strEE 3
,EE3 4
nullableFF 
:FF 
trueFF 
,FF 

oldClrTypeGG 
:GG 
typeofGG "
(GG" #
DateTimeGG# +
)GG+ ,
,GG, -
oldTypeHH 
:HH 
$strHH 3
,HH3 4
oldNullableII 
:II 
trueII !
)II! "
;II" #
migrationBuilderKK 
.KK 
AlterColumnKK (
<KK( )
DateTimeKK) 1
>KK1 2
(KK2 3
nameLL 
:LL 
$strLL $
,LL$ %
tableMM 
:MM 
$strMM .
,MM. /
typeNN 
:NN 
$strNN 3
,NN3 4
nullableOO 
:OO 
trueOO 
,OO 

oldClrTypePP 
:PP 
typeofPP "
(PP" #
DateTimePP# +
)PP+ ,
,PP, -
oldTypeQQ 
:QQ 
$strQQ 3
,QQ3 4
oldNullableRR 
:RR 
trueRR !
)RR! "
;RR" #
migrationBuilderTT 
.TT 
AlterColumnTT (
<TT( )
DateTimeTT) 1
>TT1 2
(TT2 3
nameUU 
:UU 
$strUU #
,UU# $
tableVV 
:VV 
$strVV .
,VV. /
typeWW 
:WW 
$strWW 3
,WW3 4
nullableXX 
:XX 
falseXX 
,XX  

oldClrTypeYY 
:YY 
typeofYY "
(YY" #
DateTimeYY# +
)YY+ ,
,YY, -
oldTypeZZ 
:ZZ 
$strZZ 3
)ZZ3 4
;ZZ4 5
migrationBuilder\\ 
.\\ 
AlterColumn\\ (
<\\( )
DateTime\\) 1
>\\1 2
(\\2 3
name]] 
:]] 
$str]] (
,]]( )
table^^ 
:^^ 
$str^^ %
,^^% &
type__ 
:__ 
$str__ 3
,__3 4
nullable`` 
:`` 
true`` 
,`` 

oldClrTypeaa 
:aa 
typeofaa "
(aa" #
DateTimeaa# +
)aa+ ,
,aa, -
oldTypebb 
:bb 
$strbb 3
,bb3 4
oldNullablecc 
:cc 
truecc !
)cc! "
;cc" #
}dd 	
	protectedgg 
overridegg 
voidgg 
Downgg  $
(gg$ %
MigrationBuildergg% 5
migrationBuildergg6 F
)ggF G
{hh 	
migrationBuilderii 
.ii 
AlterColumnii (
<ii( )
DateTimeii) 1
>ii1 2
(ii2 3
namejj 
:jj 
$strjj $
,jj$ %
tablekk 
:kk 
$strkk %
,kk% &
typell 
:ll 
$strll 0
,ll0 1
nullablemm 
:mm 
truemm 
,mm 

oldClrTypenn 
:nn 
typeofnn "
(nn" #
DateTimenn# +
)nn+ ,
,nn, -
oldTypeoo 
:oo 
$stroo 6
,oo6 7
oldNullablepp 
:pp 
truepp !
)pp! "
;pp" #
migrationBuilderrr 
.rr 
AlterColumnrr (
<rr( )
DateTimerr) 1
>rr1 2
(rr2 3
namess 
:ss 
$strss $
,ss$ %
tablett 
:tt 
$strtt %
,tt% &
typeuu 
:uu 
$struu 0
,uu0 1
nullablevv 
:vv 
truevv 
,vv 

oldClrTypeww 
:ww 
typeofww "
(ww" #
DateTimeww# +
)ww+ ,
,ww, -
oldTypexx 
:xx 
$strxx 6
,xx6 7
oldNullableyy 
:yy 
trueyy !
)yy! "
;yy" #
migrationBuilder{{ 
.{{ 
AlterColumn{{ (
<{{( )
float{{) .
>{{. /
({{/ 0
name|| 
:|| 
$str|| #
,||# $
table}} 
:}} 
$str}}  
,}}  !
type~~ 
:~~ 
$str~~ 
,~~ 
nullable 
: 
false 
,  

oldClrType
ÄÄ 
:
ÄÄ 
typeof
ÄÄ "
(
ÄÄ" #
string
ÄÄ# )
)
ÄÄ) *
,
ÄÄ* +
oldType
ÅÅ 
:
ÅÅ 
$str
ÅÅ 
)
ÅÅ  
;
ÅÅ  !
migrationBuilder
ÉÉ 
.
ÉÉ 
AlterColumn
ÉÉ (
<
ÉÉ( )
float
ÉÉ) .
>
ÉÉ. /
(
ÉÉ/ 0
name
ÑÑ 
:
ÑÑ 
$str
ÑÑ #
,
ÑÑ# $
table
ÖÖ 
:
ÖÖ 
$str
ÖÖ  
,
ÖÖ  !
type
ÜÜ 
:
ÜÜ 
$str
ÜÜ 
,
ÜÜ 
nullable
áá 
:
áá 
false
áá 
,
áá  

oldClrType
àà 
:
àà 
typeof
àà "
(
àà" #
string
àà# )
)
àà) *
,
àà* +
oldType
ââ 
:
ââ 
$str
ââ 
)
ââ  
;
ââ  !
migrationBuilder
ãã 
.
ãã 
AlterColumn
ãã (
<
ãã( )
DateTime
ãã) 1
>
ãã1 2
(
ãã2 3
name
åå 
:
åå 
$str
åå $
,
åå$ %
table
çç 
:
çç 
$str
çç  
,
çç  !
type
éé 
:
éé 
$str
éé 0
,
éé0 1
nullable
èè 
:
èè 
true
èè 
,
èè 

oldClrType
êê 
:
êê 
typeof
êê "
(
êê" #
DateTime
êê# +
)
êê+ ,
,
êê, -
oldType
ëë 
:
ëë 
$str
ëë 6
,
ëë6 7
oldNullable
íí 
:
íí 
true
íí !
)
íí! "
;
íí" #
migrationBuilder
îî 
.
îî 
AlterColumn
îî (
<
îî( )
DateTime
îî) 1
>
îî1 2
(
îî2 3
name
ïï 
:
ïï 
$str
ïï $
,
ïï$ %
table
ññ 
:
ññ 
$str
ññ  
,
ññ  !
type
óó 
:
óó 
$str
óó 0
,
óó0 1
nullable
òò 
:
òò 
true
òò 
,
òò 

oldClrType
ôô 
:
ôô 
typeof
ôô "
(
ôô" #
DateTime
ôô# +
)
ôô+ ,
,
ôô, -
oldType
öö 
:
öö 
$str
öö 6
,
öö6 7
oldNullable
õõ 
:
õõ 
true
õõ !
)
õõ! "
;
õõ" #
migrationBuilder
ùù 
.
ùù 
AlterColumn
ùù (
<
ùù( )
DateTime
ùù) 1
>
ùù1 2
(
ùù2 3
name
ûû 
:
ûû 
$str
ûû $
,
ûû$ %
table
üü 
:
üü 
$str
üü .
,
üü. /
type
†† 
:
†† 
$str
†† 0
,
††0 1
nullable
°° 
:
°° 
true
°° 
,
°° 

oldClrType
¢¢ 
:
¢¢ 
typeof
¢¢ "
(
¢¢" #
DateTime
¢¢# +
)
¢¢+ ,
,
¢¢, -
oldType
££ 
:
££ 
$str
££ 6
,
££6 7
oldNullable
§§ 
:
§§ 
true
§§ !
)
§§! "
;
§§" #
migrationBuilder
¶¶ 
.
¶¶ 
AlterColumn
¶¶ (
<
¶¶( )
DateTime
¶¶) 1
>
¶¶1 2
(
¶¶2 3
name
ßß 
:
ßß 
$str
ßß $
,
ßß$ %
table
®® 
:
®® 
$str
®® .
,
®®. /
type
©© 
:
©© 
$str
©© 0
,
©©0 1
nullable
™™ 
:
™™ 
true
™™ 
,
™™ 

oldClrType
´´ 
:
´´ 
typeof
´´ "
(
´´" #
DateTime
´´# +
)
´´+ ,
,
´´, -
oldType
¨¨ 
:
¨¨ 
$str
¨¨ 6
,
¨¨6 7
oldNullable
≠≠ 
:
≠≠ 
true
≠≠ !
)
≠≠! "
;
≠≠" #
migrationBuilder
ØØ 
.
ØØ 
AlterColumn
ØØ (
<
ØØ( )
DateTime
ØØ) 1
>
ØØ1 2
(
ØØ2 3
name
∞∞ 
:
∞∞ 
$str
∞∞ #
,
∞∞# $
table
±± 
:
±± 
$str
±± .
,
±±. /
type
≤≤ 
:
≤≤ 
$str
≤≤ 0
,
≤≤0 1
nullable
≥≥ 
:
≥≥ 
false
≥≥ 
,
≥≥  

oldClrType
¥¥ 
:
¥¥ 
typeof
¥¥ "
(
¥¥" #
DateTime
¥¥# +
)
¥¥+ ,
,
¥¥, -
oldType
µµ 
:
µµ 
$str
µµ 6
)
µµ6 7
;
µµ7 8
migrationBuilder
∑∑ 
.
∑∑ 
AlterColumn
∑∑ (
<
∑∑( )
DateTime
∑∑) 1
>
∑∑1 2
(
∑∑2 3
name
∏∏ 
:
∏∏ 
$str
∏∏ (
,
∏∏( )
table
ππ 
:
ππ 
$str
ππ %
,
ππ% &
type
∫∫ 
:
∫∫ 
$str
∫∫ 0
,
∫∫0 1
nullable
ªª 
:
ªª 
true
ªª 
,
ªª 

oldClrType
ºº 
:
ºº 
typeof
ºº "
(
ºº" #
DateTime
ºº# +
)
ºº+ ,
,
ºº, -
oldType
ΩΩ 
:
ΩΩ 
$str
ΩΩ 6
,
ΩΩ6 7
oldNullable
ææ 
:
ææ 
true
ææ !
)
ææ! "
;
ææ" #
}
øø 	
}
¿¿ 
}¡¡ êg
¶D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Migrations\20240707081638_UpdateDbSetUpFieldsB01.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "

Migrations" ,
{ 
public		 

partial		 
class		 "
UpdateDbSetUpFieldsB01		 /
:		0 1
	Migration		2 ;
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
AlterColumn (
<( )
DateTime) 1
>1 2
(2 3
name 
: 
$str $
,$ %
table 
: 
$str %
,% &
type 
: 
$str 0
,0 1
nullable 
: 
true 
, 

oldClrType 
: 
typeof "
(" #
DateTime# +
)+ ,
,, -
oldType 
: 
$str 3
)3 4
;4 5
migrationBuilder 
. 
AlterColumn (
<( )
DateTime) 1
>1 2
(2 3
name 
: 
$str $
,$ %
table 
: 
$str %
,% &
type 
: 
$str 0
,0 1
nullable 
: 
true 
, 

oldClrType 
: 
typeof "
(" #
DateTime# +
)+ ,
,, -
oldType 
: 
$str 3
)3 4
;4 5
migrationBuilder 
. 
AlterColumn (
<( )
DateTime) 1
>1 2
(2 3
name 
: 
$str $
,$ %
table   
:   
$str    
,    !
type!! 
:!! 
$str!! 0
,!!0 1
nullable"" 
:"" 
true"" 
,"" 

oldClrType## 
:## 
typeof## "
(##" #
DateTime### +
)##+ ,
,##, -
oldType$$ 
:$$ 
$str$$ 3
)$$3 4
;$$4 5
migrationBuilder&& 
.&& 
AlterColumn&& (
<&&( )
DateTime&&) 1
>&&1 2
(&&2 3
name'' 
:'' 
$str'' $
,''$ %
table(( 
:(( 
$str((  
,((  !
type)) 
:)) 
$str)) 0
,))0 1
nullable** 
:** 
true** 
,** 

oldClrType++ 
:++ 
typeof++ "
(++" #
DateTime++# +
)+++ ,
,++, -
oldType,, 
:,, 
$str,, 3
),,3 4
;,,4 5
migrationBuilder.. 
... 
AlterColumn.. (
<..( )
DateTime..) 1
>..1 2
(..2 3
name// 
:// 
$str// $
,//$ %
table00 
:00 
$str00 .
,00. /
type11 
:11 
$str11 0
,110 1
nullable22 
:22 
true22 
,22 

oldClrType33 
:33 
typeof33 "
(33" #
DateTime33# +
)33+ ,
,33, -
oldType44 
:44 
$str44 3
)443 4
;444 5
migrationBuilder66 
.66 
AlterColumn66 (
<66( )
DateTime66) 1
>661 2
(662 3
name77 
:77 
$str77 $
,77$ %
table88 
:88 
$str88 .
,88. /
type99 
:99 
$str99 0
,990 1
nullable:: 
::: 
true:: 
,:: 

oldClrType;; 
:;; 
typeof;; "
(;;" #
DateTime;;# +
);;+ ,
,;;, -
oldType<< 
:<< 
$str<< 3
)<<3 4
;<<4 5
migrationBuilder>> 
.>> 
AlterColumn>> (
<>>( )
DateTime>>) 1
>>>1 2
(>>2 3
name?? 
:?? 
$str?? (
,??( )
table@@ 
:@@ 
$str@@ %
,@@% &
typeAA 
:AA 
$strAA 0
,AA0 1
nullableBB 
:BB 
trueBB 
,BB 

oldClrTypeCC 
:CC 
typeofCC "
(CC" #
DateTimeCC# +
)CC+ ,
,CC, -
oldTypeDD 
:DD 
$strDD 3
)DD3 4
;DD4 5
}EE 	
	protectedHH 
overrideHH 
voidHH 
DownHH  $
(HH$ %
MigrationBuilderHH% 5
migrationBuilderHH6 F
)HHF G
{II 	
migrationBuilderJJ 
.JJ 
AlterColumnJJ (
<JJ( )
DateTimeJJ) 1
>JJ1 2
(JJ2 3
nameKK 
:KK 
$strKK $
,KK$ %
tableLL 
:LL 
$strLL %
,LL% &
typeMM 
:MM 
$strMM 0
,MM0 1
nullableNN 
:NN 
falseNN 
,NN  
defaultValueOO 
:OO 
newOO !
DateTimeOO" *
(OO* +
$numOO+ ,
,OO, -
$numOO. /
,OO/ 0
$numOO1 2
,OO2 3
$numOO4 5
,OO5 6
$numOO7 8
,OO8 9
$numOO: ;
,OO; <
$numOO= >
,OO> ?
DateTimeKindOO@ L
.OOL M
UnspecifiedOOM X
)OOX Y
,OOY Z

oldClrTypePP 
:PP 
typeofPP "
(PP" #
DateTimePP# +
)PP+ ,
,PP, -
oldTypeQQ 
:QQ 
$strQQ 3
,QQ3 4
oldNullableRR 
:RR 
trueRR !
)RR! "
;RR" #
migrationBuilderTT 
.TT 
AlterColumnTT (
<TT( )
DateTimeTT) 1
>TT1 2
(TT2 3
nameUU 
:UU 
$strUU $
,UU$ %
tableVV 
:VV 
$strVV %
,VV% &
typeWW 
:WW 
$strWW 0
,WW0 1
nullableXX 
:XX 
falseXX 
,XX  
defaultValueYY 
:YY 
newYY !
DateTimeYY" *
(YY* +
$numYY+ ,
,YY, -
$numYY. /
,YY/ 0
$numYY1 2
,YY2 3
$numYY4 5
,YY5 6
$numYY7 8
,YY8 9
$numYY: ;
,YY; <
$numYY= >
,YY> ?
DateTimeKindYY@ L
.YYL M
UnspecifiedYYM X
)YYX Y
,YYY Z

oldClrTypeZZ 
:ZZ 
typeofZZ "
(ZZ" #
DateTimeZZ# +
)ZZ+ ,
,ZZ, -
oldType[[ 
:[[ 
$str[[ 3
,[[3 4
oldNullable\\ 
:\\ 
true\\ !
)\\! "
;\\" #
migrationBuilder^^ 
.^^ 
AlterColumn^^ (
<^^( )
DateTime^^) 1
>^^1 2
(^^2 3
name__ 
:__ 
$str__ $
,__$ %
table`` 
:`` 
$str``  
,``  !
typeaa 
:aa 
$straa 0
,aa0 1
nullablebb 
:bb 
falsebb 
,bb  
defaultValuecc 
:cc 
newcc !
DateTimecc" *
(cc* +
$numcc+ ,
,cc, -
$numcc. /
,cc/ 0
$numcc1 2
,cc2 3
$numcc4 5
,cc5 6
$numcc7 8
,cc8 9
$numcc: ;
,cc; <
$numcc= >
,cc> ?
DateTimeKindcc@ L
.ccL M
UnspecifiedccM X
)ccX Y
,ccY Z

oldClrTypedd 
:dd 
typeofdd "
(dd" #
DateTimedd# +
)dd+ ,
,dd, -
oldTypeee 
:ee 
$stree 3
,ee3 4
oldNullableff 
:ff 
trueff !
)ff! "
;ff" #
migrationBuilderhh 
.hh 
AlterColumnhh (
<hh( )
DateTimehh) 1
>hh1 2
(hh2 3
nameii 
:ii 
$strii $
,ii$ %
tablejj 
:jj 
$strjj  
,jj  !
typekk 
:kk 
$strkk 0
,kk0 1
nullablell 
:ll 
falsell 
,ll  
defaultValuemm 
:mm 
newmm !
DateTimemm" *
(mm* +
$nummm+ ,
,mm, -
$nummm. /
,mm/ 0
$nummm1 2
,mm2 3
$nummm4 5
,mm5 6
$nummm7 8
,mm8 9
$nummm: ;
,mm; <
$nummm= >
,mm> ?
DateTimeKindmm@ L
.mmL M
UnspecifiedmmM X
)mmX Y
,mmY Z

oldClrTypenn 
:nn 
typeofnn "
(nn" #
DateTimenn# +
)nn+ ,
,nn, -
oldTypeoo 
:oo 
$stroo 3
,oo3 4
oldNullablepp 
:pp 
truepp !
)pp! "
;pp" #
migrationBuilderrr 
.rr 
AlterColumnrr (
<rr( )
DateTimerr) 1
>rr1 2
(rr2 3
namess 
:ss 
$strss $
,ss$ %
tablett 
:tt 
$strtt .
,tt. /
typeuu 
:uu 
$struu 0
,uu0 1
nullablevv 
:vv 
falsevv 
,vv  
defaultValueww 
:ww 
newww !
DateTimeww" *
(ww* +
$numww+ ,
,ww, -
$numww. /
,ww/ 0
$numww1 2
,ww2 3
$numww4 5
,ww5 6
$numww7 8
,ww8 9
$numww: ;
,ww; <
$numww= >
,ww> ?
DateTimeKindww@ L
.wwL M
UnspecifiedwwM X
)wwX Y
,wwY Z

oldClrTypexx 
:xx 
typeofxx "
(xx" #
DateTimexx# +
)xx+ ,
,xx, -
oldTypeyy 
:yy 
$stryy 3
,yy3 4
oldNullablezz 
:zz 
truezz !
)zz! "
;zz" #
migrationBuilder|| 
.|| 
AlterColumn|| (
<||( )
DateTime||) 1
>||1 2
(||2 3
name}} 
:}} 
$str}} $
,}}$ %
table~~ 
:~~ 
$str~~ .
,~~. /
type 
: 
$str 0
,0 1
nullable
ÄÄ 
:
ÄÄ 
false
ÄÄ 
,
ÄÄ  
defaultValue
ÅÅ 
:
ÅÅ 
new
ÅÅ !
DateTime
ÅÅ" *
(
ÅÅ* +
$num
ÅÅ+ ,
,
ÅÅ, -
$num
ÅÅ. /
,
ÅÅ/ 0
$num
ÅÅ1 2
,
ÅÅ2 3
$num
ÅÅ4 5
,
ÅÅ5 6
$num
ÅÅ7 8
,
ÅÅ8 9
$num
ÅÅ: ;
,
ÅÅ; <
$num
ÅÅ= >
,
ÅÅ> ?
DateTimeKind
ÅÅ@ L
.
ÅÅL M
Unspecified
ÅÅM X
)
ÅÅX Y
,
ÅÅY Z

oldClrType
ÇÇ 
:
ÇÇ 
typeof
ÇÇ "
(
ÇÇ" #
DateTime
ÇÇ# +
)
ÇÇ+ ,
,
ÇÇ, -
oldType
ÉÉ 
:
ÉÉ 
$str
ÉÉ 3
,
ÉÉ3 4
oldNullable
ÑÑ 
:
ÑÑ 
true
ÑÑ !
)
ÑÑ! "
;
ÑÑ" #
migrationBuilder
ÜÜ 
.
ÜÜ 
AlterColumn
ÜÜ (
<
ÜÜ( )
DateTime
ÜÜ) 1
>
ÜÜ1 2
(
ÜÜ2 3
name
áá 
:
áá 
$str
áá (
,
áá( )
table
àà 
:
àà 
$str
àà %
,
àà% &
type
ââ 
:
ââ 
$str
ââ 0
,
ââ0 1
nullable
ää 
:
ää 
false
ää 
,
ää  
defaultValue
ãã 
:
ãã 
new
ãã !
DateTime
ãã" *
(
ãã* +
$num
ãã+ ,
,
ãã, -
$num
ãã. /
,
ãã/ 0
$num
ãã1 2
,
ãã2 3
$num
ãã4 5
,
ãã5 6
$num
ãã7 8
,
ãã8 9
$num
ãã: ;
,
ãã; <
$num
ãã= >
,
ãã> ?
DateTimeKind
ãã@ L
.
ããL M
Unspecified
ããM X
)
ããX Y
,
ããY Z

oldClrType
åå 
:
åå 
typeof
åå "
(
åå" #
DateTime
åå# +
)
åå+ ,
,
åå, -
oldType
çç 
:
çç 
$str
çç 3
,
çç3 4
oldNullable
éé 
:
éé 
true
éé !
)
éé! "
;
éé" #
}
èè 	
}
êê 
}ëë ƒ@
£D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Migrations\20240707065844_UpdateDbEntitiesB02.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "

Migrations" ,
{ 
public		 

partial		 
class		 
UpdateDbEntitiesB02		 ,
:		- .
	Migration		/ 8
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str $
,$ %
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 8
,8 9
nullable: B
:B C
falseD I
)I J
,J K
	BrandCode 
= 
table  %
.% &
Column& ,
<, -
string- 3
>3 4
(4 5
type5 9
:9 :
$str; A
,A B
nullableC K
:K L
falseM R
)R S
,S T

BrandNName 
=  
table! &
.& '
Column' -
<- .
string. 4
>4 5
(5 6
type6 :
:: ;
$str< B
,B C
nullableD L
:L M
falseN S
)S T
,T U
DateOfCreate  
=! "
table# (
.( )
Column) /
</ 0
DateTime0 8
>8 9
(9 :
type: >
:> ?
$str@ Z
,Z [
nullable\ d
:d e
falsef k
)k l
,l m
DateOfUpdate  
=! "
table# (
.( )
Column) /
</ 0
DateTime0 8
>8 9
(9 :
type: >
:> ?
$str@ Z
,Z [
nullable\ d
:d e
falsef k
)k l
,l m
Description 
=  !
table" '
.' (
Column( .
<. /
string/ 5
>5 6
(6 7
type7 ;
:; <
$str= C
,C D
nullableE M
:M N
falseO T
)T U
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 6
,6 7
x8 9
=>: <
x= >
.> ?
Id? A
)A B
;B C
} 
) 
; 
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str 
,  
columns   
:   
table   
=>   !
new  " %
{!! 
Id"" 
="" 
table"" 
."" 
Column"" %
<""% &
Guid""& *
>""* +
(""+ ,
type"", 0
:""0 1
$str""2 8
,""8 9
nullable"": B
:""B C
false""D I
)""I J
,""J K
DateOfCreate##  
=##! "
table### (
.##( )
Column##) /
<##/ 0
DateTime##0 8
>##8 9
(##9 :
type##: >
:##> ?
$str##@ Z
,##Z [
nullable##\ d
:##d e
false##f k
)##k l
,##l m
DateOfUpdate$$  
=$$! "
table$$# (
.$$( )
Column$$) /
<$$/ 0
DateTime$$0 8
>$$8 9
($$9 :
type$$: >
:$$> ?
$str$$@ Z
,$$Z [
nullable$$\ d
:$$d e
false$$f k
)$$k l
,$$l m
Description%% 
=%%  !
table%%" '
.%%' (
Column%%( .
<%%. /
string%%/ 5
>%%5 6
(%%6 7
type%%7 ;
:%%; <
$str%%= C
,%%C D
nullable%%E M
:%%M N
false%%O T
)%%T U
,%%U V
OriginalPrice&& !
=&&" #
table&&$ )
.&&) *
Column&&* 0
<&&0 1
float&&1 6
>&&6 7
(&&7 8
type&&8 <
:&&< =
$str&&> D
,&&D E
nullable&&F N
:&&N O
false&&P U
)&&U V
,&&V W
ProductCode'' 
=''  !
table''" '
.''' (
Column''( .
<''. /
float''/ 4
>''4 5
(''5 6
type''6 :
:'': ;
$str''< B
,''B C
nullable''D L
:''L M
false''N S
)''S T
,''T U
ProductName(( 
=((  !
table((" '
.((' (
Column((( .
<((. /
float((/ 4
>((4 5
(((5 6
type((6 :
:((: ;
$str((< B
,((B C
nullable((D L
:((L M
false((N S
)((S T
,((T U
Quantity)) 
=)) 
table)) $
.))$ %
Column))% +
<))+ ,
int)), /
>))/ 0
())0 1
type))1 5
:))5 6
$str))7 @
,))@ A
nullable))B J
:))J K
false))L Q
)))Q R
,))R S
StatusId** 
=** 
table** $
.**$ %
Column**% +
<**+ ,
string**, 2
>**2 3
(**3 4
type**4 8
:**8 9
$str**: @
,**@ A
nullable**B J
:**J K
false**L Q
)**Q R
,**R S
ProductBrandId++ "
=++# $
table++% *
.++* +
Column+++ 1
<++1 2
Guid++2 6
>++6 7
(++7 8
type++8 <
:++< =
$str++> D
,++D E
nullable++F N
:++N O
false++P U
)++U V
},, 
,,, 
constraints-- 
:-- 
table-- "
=>--# %
{.. 
table// 
.// 

PrimaryKey// $
(//$ %
$str//% 1
,//1 2
x//3 4
=>//5 7
x//8 9
.//9 :
Id//: <
)//< =
;//= >
table00 
.00 

ForeignKey00 $
(00$ %
name11 
:11 
$str11 F
,11F G
column22 
:22 
x22  !
=>22" $
x22% &
.22& '
ProductBrandId22' 5
,225 6
principalTable33 &
:33& '
$str33( 6
,336 7
principalColumn44 '
:44' (
$str44) -
,44- .
onDelete55  
:55  !
ReferentialAction55" 3
.553 4
Cascade554 ;
)55; <
;55< =
}66 
)66 
;66 
migrationBuilder88 
.88 
CreateIndex88 (
(88( )
name99 
:99 
$str99 1
,991 2
table:: 
::: 
$str::  
,::  !
column;; 
:;; 
$str;; (
);;( )
;;;) *
}<< 	
	protected?? 
override?? 
void?? 
Down??  $
(??$ %
MigrationBuilder??% 5
migrationBuilder??6 F
)??F G
{@@ 	
migrationBuilderAA 
.AA 
	DropTableAA &
(AA& '
nameBB 
:BB 
$strBB 
)BB  
;BB  !
migrationBuilderDD 
.DD 
	DropTableDD &
(DD& '
nameEE 
:EE 
$strEE $
)EE$ %
;EE% &
}FF 	
}GG 
}HH í}
úD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Migrations\20240706095740_UpdateEnDb01.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "

Migrations" ,
{ 
public		 

partial		 
class		 
UpdateEnDb01		 %
:		& '
	Migration		( 1
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str -
,- .
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 8
,8 9
nullable: B
:B C
falseD I
)I J
,J K
Address 
= 
table #
.# $
Column$ *
<* +
string+ 1
>1 2
(2 3
type3 7
:7 8
$str9 ?
,? @
nullableA I
:I J
falseK P
)P Q
,Q R
DateOfBirth 
=  !
table" '
.' (
Column( .
<. /
DateTime/ 7
>7 8
(8 9
type9 =
:= >
$str? Y
,Y Z
nullable[ c
:c d
falsee j
)j k
,k l
DateOfCreate  
=! "
table# (
.( )
Column) /
</ 0
DateTime0 8
>8 9
(9 :
type: >
:> ?
$str@ Z
,Z [
nullable\ d
:d e
falsef k
)k l
,l m
DateOfUpdate  
=! "
table# (
.( )
Column) /
</ 0
DateTime0 8
>8 9
(9 :
type: >
:> ?
$str@ Z
,Z [
nullable\ d
:d e
falsef k
)k l
,l m
Email 
= 
table !
.! "
Column" (
<( )
string) /
>/ 0
(0 1
type1 5
:5 6
$str7 =
,= >
nullable? G
:G H
falseI N
)N O
,O P
FullName 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: @
,@ A
nullableB J
:J K
falseL Q
)Q R
,R S
Gender 
= 
table "
." #
Column# )
<) *
string* 0
>0 1
(1 2
type2 6
:6 7
$str8 >
,> ?
nullable@ H
:H I
falseJ O
)O P
,P Q
IsActive 
= 
table $
.$ %
Column% +
<+ ,
bool, 0
>0 1
(1 2
type2 6
:6 7
$str8 A
,A B
nullableC K
:K L
falseM R
)R S
,S T

NationalId 
=  
table! &
.& '
Column' -
<- .
string. 4
>4 5
(5 6
type6 :
:: ;
$str< B
,B C
nullableD L
:L M
falseN S
)S T
,T U
Password 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: @
,@ A
nullableB J
:J K
falseL Q
)Q R
,R S
PhoneNumber 
=  !
table" '
.' (
Column( .
<. /
string/ 5
>5 6
(6 7
type7 ;
:; <
$str= C
,C D
nullableE M
:M N
falseO T
)T U
,U V
UserName 
= 
table $
.$ %
Column% +
<+ ,
string, 2
>2 3
(3 4
type4 8
:8 9
$str: @
,@ A
nullableB J
:J K
falseL Q
)Q R
,R S
	GenRoleId 
= 
table  %
.% &
Column& ,
<, -
Guid- 1
>1 2
(2 3
type3 7
:7 8
$str9 ?
,? @
nullableA I
:I J
falseK P
)P Q
}   
,   
constraints!! 
:!! 
table!! "
=>!!# %
{"" 
table## 
.## 

PrimaryKey## $
(##$ %
$str##% ?
,##? @
x##A B
=>##C E
x##F G
.##G H
Id##H J
)##J K
;##K L
table$$ 
.$$ 

ForeignKey$$ $
($$$ %
name%% 
:%% 
$str%% T
,%%T U
column&& 
:&& 
x&&  !
=>&&" $
x&&% &
.&&& '
	GenRoleId&&' 0
,&&0 1
principalTable'' &
:''& '
$str''( ;
,''; <
principalColumn(( '
:((' (
$str(() -
,((- .
onDelete))  
:))  !
ReferentialAction))" 3
.))3 4
Cascade))4 ;
))); <
;))< =
}** 
)** 
;** 
migrationBuilder,, 
.,, 
CreateTable,, (
(,,( )
name-- 
:-- 
$str-- '
,--' (
columns.. 
:.. 
table.. 
=>.. !
new.." %
{// 
Id00 
=00 
table00 
.00 
Column00 %
<00% &
Guid00& *
>00* +
(00+ ,
type00, 0
:000 1
$str002 8
,008 9
nullable00: B
:00B C
false00D I
)00I J
,00J K
StaffRoleCode11 !
=11" #
table11$ )
.11) *
Column11* 0
<110 1
string111 7
>117 8
(118 9
type119 =
:11= >
$str11? E
,11E F
nullable11G O
:11O P
false11Q V
)11V W
,11W X
StaffRoleTitle22 "
=22# $
table22% *
.22* +
Column22+ 1
<221 2
string222 8
>228 9
(229 :
type22: >
:22> ?
$str22@ F
,22F G
nullable22H P
:22P Q
false22R W
)22W X
}33 
,33 
constraints44 
:44 
table44 "
=>44# %
{55 
table66 
.66 

PrimaryKey66 $
(66$ %
$str66% 9
,669 :
x66; <
=>66= ?
x66@ A
.66A B
Id66B D
)66D E
;66E F
}77 
)77 
;77 
migrationBuilder99 
.99 
CreateTable99 (
(99( )
name:: 
::: 
$str:: $
,::$ %
columns;; 
:;; 
table;; 
=>;; !
new;;" %
{<< 
Id== 
=== 
table== 
.== 
Column== %
<==% &
Guid==& *
>==* +
(==+ ,
type==, 0
:==0 1
$str==2 8
,==8 9
nullable==: B
:==B C
false==D I
)==I J
,==J K
CustomerCode>>  
=>>! "
table>># (
.>>( )
Column>>) /
<>>/ 0
string>>0 6
>>>6 7
(>>7 8
type>>8 <
:>>< =
$str>>> D
,>>D E
nullable>>F N
:>>N O
false>>P U
)>>U V
,>>V W
CustomerPoint?? !
=??" #
table??$ )
.??) *
Column??* 0
<??0 1
float??1 6
>??6 7
(??7 8
type??8 <
:??< =
$str??> D
,??D E
nullable??F N
:??N O
false??P U
)??U V
,??V W
LastPurchaseDate@@ $
=@@% &
table@@' ,
.@@, -
Column@@- 3
<@@3 4
DateTime@@4 <
>@@< =
(@@= >
type@@> B
:@@B C
$str@@D ^
,@@^ _
nullable@@` h
:@@h i
false@@j o
)@@o p
,@@p q
GenUserInfoIdAA !
=AA" #
tableAA$ )
.AA) *
ColumnAA* 0
<AA0 1
GuidAA1 5
>AA5 6
(AA6 7
typeAA7 ;
:AA; <
$strAA= C
,AAC D
nullableAAE M
:AAM N
falseAAO T
)AAT U
}BB 
,BB 
constraintsCC 
:CC 
tableCC "
=>CC# %
{DD 
tableEE 
.EE 

PrimaryKeyEE $
(EE$ %
$strEE% 6
,EE6 7
xEE8 9
=>EE: <
xEE= >
.EE> ?
IdEE? A
)EEA B
;EEB C
tableFF 
.FF 

ForeignKeyFF $
(FF$ %
nameGG 
:GG 
$strGG S
,GGS T
columnHH 
:HH 
xHH  !
=>HH" $
xHH% &
.HH& '
GenUserInfoIdHH' 4
,HH4 5
principalTableII &
:II& '
$strII( ?
,II? @
principalColumnJJ '
:JJ' (
$strJJ) -
,JJ- .
onDeleteKK  
:KK  !
ReferentialActionKK" 3
.KK3 4
CascadeKK4 ;
)KK; <
;KK< =
}LL 
)LL 
;LL 
migrationBuilderNN 
.NN 
CreateTableNN (
(NN( )
nameOO 
:OO 
$strOO "
,OO" #
columnsPP 
:PP 
tablePP 
=>PP !
newPP" %
{QQ 
IdRR 
=RR 
tableRR 
.RR 
ColumnRR %
<RR% &
GuidRR& *
>RR* +
(RR+ ,
typeRR, 0
:RR0 1
$strRR2 8
,RR8 9
nullableRR: B
:RRB C
falseRRD I
)RRI J
,RRJ K
StaffRoleCodeSS !
=SS" #
tableSS$ )
.SS) *
ColumnSS* 0
<SS0 1
stringSS1 7
>SS7 8
(SS8 9
typeSS9 =
:SS= >
$strSS? E
,SSE F
nullableSSG O
:SSO P
falseSSQ V
)SSV W
,SSW X
StaffRoleTitleTT "
=TT# $
tableTT% *
.TT* +
ColumnTT+ 1
<TT1 2
stringTT2 8
>TT8 9
(TT9 :
typeTT: >
:TT> ?
$strTT@ F
,TTF G
nullableTTH P
:TTP Q
falseTTR W
)TTW X
,TTX Y
StaffRoleIdUU 
=UU  !
tableUU" '
.UU' (
ColumnUU( .
<UU. /
GuidUU/ 3
>UU3 4
(UU4 5
typeUU5 9
:UU9 :
$strUU; A
,UUA B
nullableUUC K
:UUK L
falseUUM R
)UUR S
,UUS T
GenUserInfoIdVV !
=VV" #
tableVV$ )
.VV) *
ColumnVV* 0
<VV0 1
GuidVV1 5
>VV5 6
(VV6 7
typeVV7 ;
:VV; <
$strVV= C
,VVC D
nullableVVE M
:VVM N
falseVVO T
)VVT U
}WW 
,WW 
constraintsXX 
:XX 
tableXX "
=>XX# %
{YY 
tableZZ 
.ZZ 

PrimaryKeyZZ $
(ZZ$ %
$strZZ% 4
,ZZ4 5
xZZ6 7
=>ZZ8 :
xZZ; <
.ZZ< =
IdZZ= ?
)ZZ? @
;ZZ@ A
table[[ 
.[[ 

ForeignKey[[ $
([[$ %
name\\ 
:\\ 
$str\\ Q
,\\Q R
column]] 
:]] 
x]]  !
=>]]" $
x]]% &
.]]& '
GenUserInfoId]]' 4
,]]4 5
principalTable^^ &
:^^& '
$str^^( ?
,^^? @
principalColumn__ '
:__' (
$str__) -
,__- .
onDelete``  
:``  !
ReferentialAction``" 3
.``3 4
Cascade``4 ;
)``; <
;``< =
tableaa 
.aa 

ForeignKeyaa $
(aa$ %
namebb 
:bb 
$strbb I
,bbI J
columncc 
:cc 
xcc  !
=>cc" $
xcc% &
.cc& '
StaffRoleIdcc' 2
,cc2 3
principalTabledd &
:dd& '
$strdd( 9
,dd9 :
principalColumnee '
:ee' (
$stree) -
,ee- .
onDeleteff  
:ff  !
ReferentialActionff" 3
.ff3 4
Cascadeff4 ;
)ff; <
;ff< =
}gg 
)gg 
;gg 
migrationBuilderii 
.ii 
CreateIndexii (
(ii( )
namejj 
:jj 
$strjj 5
,jj5 6
tablekk 
:kk 
$strkk %
,kk% &
columnll 
:ll 
$strll '
,ll' (
uniquemm 
:mm 
truemm 
)mm 
;mm 
migrationBuilderoo 
.oo 
CreateIndexoo (
(oo( )
namepp 
:pp 
$strpp :
,pp: ;
tableqq 
:qq 
$strqq .
,qq. /
columnrr 
:rr 
$strrr #
)rr# $
;rr$ %
migrationBuildertt 
.tt 
CreateIndextt (
(tt( )
nameuu 
:uu 
$struu 3
,uu3 4
tablevv 
:vv 
$strvv #
,vv# $
columnww 
:ww 
$strww '
,ww' (
uniquexx 
:xx 
truexx 
)xx 
;xx 
migrationBuilderzz 
.zz 
CreateIndexzz (
(zz( )
name{{ 
:{{ 
$str{{ 1
,{{1 2
table|| 
:|| 
$str|| #
,||# $
column}} 
:}} 
$str}} %
)}}% &
;}}& '
}~~ 	
	protected
ÅÅ 
override
ÅÅ 
void
ÅÅ 
Down
ÅÅ  $
(
ÅÅ$ %
MigrationBuilder
ÅÅ% 5
migrationBuilder
ÅÅ6 F
)
ÅÅF G
{
ÇÇ 	
migrationBuilder
ÉÉ 
.
ÉÉ 
	DropTable
ÉÉ &
(
ÉÉ& '
name
ÑÑ 
:
ÑÑ 
$str
ÑÑ $
)
ÑÑ$ %
;
ÑÑ% &
migrationBuilder
ÜÜ 
.
ÜÜ 
	DropTable
ÜÜ &
(
ÜÜ& '
name
áá 
:
áá 
$str
áá "
)
áá" #
;
áá# $
migrationBuilder
ââ 
.
ââ 
	DropTable
ââ &
(
ââ& '
name
ää 
:
ää 
$str
ää -
)
ää- .
;
ää. /
migrationBuilder
åå 
.
åå 
	DropTable
åå &
(
åå& '
name
çç 
:
çç 
$str
çç '
)
çç' (
;
çç( )
}
éé 	
}
èè 
}êê ï
§D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Migrations\20240627150956_DbUpdate-id-type-b01.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "

Migrations" ,
{ 
public		 

partial		 
class		 
DbUpdateidtypeb01		 *
:		+ ,
	Migration		- 6
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str )
,) *
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 8
,8 9
nullable: B
:B C
falseD I
)I J
,J K
GenRoleCode 
=  !
table" '
.' (
Column( .
<. /
string/ 5
>5 6
(6 7
type7 ;
:; <
$str= C
,C D
nullableE M
:M N
falseO T
)T U
,U V
GenRoleTitle  
=! "
table# (
.( )
Column) /
</ 0
string0 6
>6 7
(7 8
type8 <
:< =
$str> D
,D E
nullableF N
:N O
falseP U
)U V
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% ;
,; <
x= >
=>? A
xB C
.C D
IdD F
)F G
;G H
} 
) 
; 
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 
	DropTable &
(& '
name   
:   
$str   )
)  ) *
;  * +
}!! 	
}"" 
}## ˜
êD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Infrastructures\UnitOfWork.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Infrastructures" 1
{ 
public 

class 

UnitOfWork 
: 
IUnitOfWork )
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
public 

UnitOfWork 
(  
PracNet7ApiDbContext .
_context/ 7
)7 8
{ 	
this 
. 
_context 
= 
_context $
;$ %
} 	
public "
IGeneralRoleRepository %!
GeneralRoleRepository& ;
=>< >
new? B!
GeneralRoleRepositoryC X
(X Y
_contextY a
)a b
;b c
public &
IGeneralUserInfoRepository )%
GeneralUserInfoRepository* C
=>D F
newG J%
GeneralUserInfoRepositoryK d
(d e
_contexte m
)m n
;n o
public #
IProductBrandRepository &"
ProductBrandRepository' =
=>> @
newA D"
ProductBrandRepositoryE [
([ \
_context\ d
)d e
;e f
public   
IProductRepository   !
ProductRepository  " 3
=>  4 6
new  7 :
ProductRepository  ; L
(  L M
_context  M U
)  U V
;  V W
public"" 
ICustomerRepository"" "
CustomerRepository""# 5
=>""6 8
new""9 <
CustomerRepository""= O
(""O P
_context""P X
)""X Y
;""Y Z
public$$  
IStaffRoleRepository$$ #
StaffRoleRepository$$$ 7
=>$$8 :
new$$; >
StaffRoleRepository$$? R
($$R S
_context$$S [
)$$[ \
;$$\ ]
public&& 
IStaffRepository&& 
StaffRepository&&  /
=>&&0 2
new&&3 6
StaffRepository&&7 F
(&&F G
_context&&G O
)&&O P
;&&P Q
public(( 
void(( 
Dispose(( 
((( 
)(( 
{)) 	
_context** 
.** 
Dispose** 
(** 
)** 
;** 
}++ 	
public-- 
int-- 
Save-- 
(-- 
)-- 
{.. 	
int// 
result// 
=// 
_context// !
.//! "
SaveChanges//" -
(//- .
)//. /
;/// 0
_context00 
.00 
ChangeTracker00 "
.00" #
Clear00# (
(00( )
)00) *
;00* +
return11 
result11 
;11 
}22 	
}33 
}44 ô
ëD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Infrastructures\IUnitOfWork.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Infrastructures" 1
{ 
public 

	interface 
IUnitOfWork  
:! "
IDisposable# .
{ "
IGeneralRoleRepository !
GeneralRoleRepository 4
{5 6
get7 :
;: ;
}< =&
IGeneralUserInfoRepository "%
GeneralUserInfoRepository# <
{= >
get? B
;B C
}D E#
IProductBrandRepository "
ProductBrandRepository  6
{7 8
get9 <
;< =
}> ?
IProductRepository 
ProductRepository ,
{- .
get/ 2
;2 3
}4 5
ICustomerRepository 
CustomerRepository .
{/ 0
get1 4
;4 5
}6 7 
IStaffRoleRepository 
StaffRoleRepository 0
{1 2
get3 6
;6 7
}8 9
IStaffRepository 
StaffRepository (
{) *
get+ .
;. /
}0 1
int 
Save 
( 
) 
; 
} 
} º
ïD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Infrastructures\IGenericService.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Infrastructures" 1
{ 
public		 

	interface		 
IGenericService		 $
<		$ %
T		% &
>		& '
{

 
List 
< 
T 
> 
FindAll 
( 
) 
; 
T 	
FindById
 
( 
Guid 
id 
) 
; 
} 
} ÿ
òD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Infrastructures\IGenericRepository.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Infrastructures" 1
{		 
public

 

	interface

 
IGenericRepository

 '
<

' (
T

( )
>

) *
{ 

IQueryable 
< 
T 
> 
FindAll 
( 
) 
;  
T 	
FindById
 
( 
Guid 
id 
) 
; 
T 	

FindById02
 
( 

Expression 
<  
Func  $
<$ %
T% &
,& '
bool( ,
>, -
>- .
	predicate/ 8
)8 9
;9 :
void 
	CreateNew 
( 
T 
entity 
)  
;  !
void 
Update 
( 
T 
entity 
) 
; 
void"" 
Delete"" 
("" 
T"" 
entity"" 
)"" 
;"" 

IQueryable33 
<33 
T33 
>33 
FindByCondition33 %
(33% &

Expression33& 0
<330 1
Func331 5
<335 6
T336 7
,337 8
bool339 =
>33= >
>33> ?
	predicate33@ I
)33I J
;33J K

IQueryable99 
<99 
T99 
>99 
FindAllInclude99 $
(99$ %
params99% +

Expression99, 6
<996 7
Func997 ;
<99; <
T99< =
,99= >
object99? E
>99E F
>99F G
[99G H
]99H I
includes99J R
)99R S
;99S T
}<< 
}== ü
îD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Infrastructures\GenericService.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Infrastructures" 1
{		 
public

 

class

 
GenericService

 
<

  
T

  !
>

! "
:

# $
IGenericService

% 4
<

4 5
T

5 6
>

6 7
where

8 =
T

> ?
:

@ A
class

B G
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
private 
readonly 
IUnitOfWork $
_unitOfWork% 0
;0 1
private 
readonly 
IGenericRepository +
<+ ,
T, -
>- .
_repository/ :
;: ;
public 
GenericService 
(  
PracNet7ApiDbContext 2
_context3 ;
,; <
IUnitOfWork= H
_unitOfWorkI T
,T U
IGenericRepositoryV h
<h i
Ti j
>j k
_repositoryl w
)w x
{ 	
this 
. 
_context 
= 
_context $
;$ %
this 
. 
_unitOfWork 
= 
_unitOfWork *
;* +
this 
. 
_repository 
= 
_repository *
;* +
} 	
public 
List 
< 
T 
> 
FindAll 
( 
)  
{ 	
try 
{ 
List 
< 
T 
> 
listData  
=! "
_repository# .
.. /
FindAll/ 6
(6 7
)7 8
.8 9
ToList9 ?
(? @
)@ A
;A B
return 
listData 
;  
} 
catch   
(   
	Exception   
)   
{!! 
throw## 
;## 
}$$ 
finally%% 
{%% 
_unitOfWork%% !
.%%! "
Dispose%%" )
(%%) *
)%%* +
;%%+ ,
}%%- .
}&& 	
public** 
T** 
FindById** 
(** 
Guid** 
id** !
)**! "
{++ 	
try,, 
{-- 
var.. 
item.. 
=.. 
_repository.. &
...& '
FindById..' /
(../ 0
id..0 2
)..2 3
;..3 4
return// 
item// 
;// 
}00 
catch11 
(11 
	Exception11 
)11 
{22 
throw44 
;44 
}55 
finally66 
{66 
_unitOfWork66 !
?66! "
.66" #
Dispose66# *
(66* +
)66+ ,
;66, -
}66. /
}77 	
}:: 
};; ∫*
óD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Infrastructures\GenericRepository.cs
	namespace

 	
PracNet7ApiProB01


 
.

 
Model

 !
.

! "
Infrastructures

" 1
{ 
public 

abstract 
class 
GenericRepository +
<+ ,
T, -
>- .
:/ 0
IGenericRepository1 C
<C D
TD E
>E F
whereG L
TM N
:O P
classQ V
{ 
private 
readonly  
PracNet7ApiDbContext -
_context. 6
;6 7
	protected 
GenericRepository #
(# $ 
PracNet7ApiDbContext$ 8
_context9 A
)A B
{ 	
this 
. 
_context 
= 
_context $
;$ %
} 	
public 
void 
	CreateNew 
( 
T 
entity  &
)& '
{ 	
_context 
. 
Set 
< 
T 
> 
( 
) 
. 
Add !
(! "
entity" (
)( )
;) *
} 	
public 
void 
Delete 
( 
T 
entity #
)# $
{ 	
_context 
. 
Set 
< 
T 
> 
( 
) 
. 
Remove $
($ %
entity% +
)+ ,
;, -
}   	
public$$ 

IQueryable$$ 
<$$ 
T$$ 
>$$ 
FindAll$$ $
($$$ %
)$$% &
{%% 	
return&& 
_context&& 
.&& 
Set&& 
<&&  
T&&  !
>&&! "
(&&" #
)&&# $
.&&$ %
AsNoTracking&&% 1
(&&1 2
)&&2 3
;&&3 4
}'' 	
public++ 

IQueryable++ 
<++ 
T++ 
>++ 
FindAllInclude++ +
(+++ ,
params++, 2

Expression++3 =
<++= >
Func++> B
<++B C
T++C D
,++D E
object++F L
>++L M
>++M N
[++N O
]++O P
includes++Q Y
)++Y Z
{,, 	
var-- 
query-- 
=-- 
_context--  
.--  !
Set--! $
<--$ %
T--% &
>--& '
(--' (
)--( )
.--) *
AsNoTracking--* 6
(--6 7
)--7 8
;--8 9
if.. 
(.. 
includes.. 
!=.. 
null..  
)..  !
{// 
foreach00 
(00 
var00 
include00 $
in00% '
includes00( 0
)000 1
{11 
query22 
=22 
query22 !
.22! "
Include22" )
(22) *
include22* 1
)221 2
;222 3
}33 
}44 
return55 
query55 
;55 
}66 	
public:: 

IQueryable:: 
<:: 
T:: 
>:: 
FindByCondition:: ,
(::, -

Expression::- 7
<::7 8
Func::8 <
<::< =
T::= >
,::> ?
bool::@ D
>::D E
>::E F
	predicate::G P
)::P Q
{;; 	
return<< 
_context<< 
.<< 
Set<< 
<<<  
T<<  !
><<! "
(<<" #
)<<# $
.<<$ %
AsNoTracking<<% 1
(<<1 2
)<<2 3
.<<3 4
Where<<4 9
(<<9 :
	predicate<<: C
)<<C D
;<<D E
}== 	
publicBB 
TBB 
FindByIdBB 
(BB 
GuidBB 
idBB !
)BB! "
{CC 	
returnDD 
_contextDD 
.DD 
SetDD 
<DD  
TDD  !
>DD! "
(DD" #
)DD# $
.DD$ %
FindDD% )
(DD) *
idDD* ,
)DD, -
;DD- .
}EE 	
publicII 
TII 

FindById02II 
(II 

ExpressionII &
<II& '
FuncII' +
<II+ ,
TII, -
,II- .
boolII/ 3
>II3 4
>II4 5
	predicateII6 ?
)II? @
{JJ 	
returnKK 
_contextKK 
.KK 
SetKK 
<KK  
TKK  !
>KK! "
(KK" #
)KK# $
.KK$ %
AsNoTrackingKK% 1
(KK1 2
)KK2 3
.KK3 4
FirstOrDefaultKK4 B
(KKB C
	predicateKKC L
)KKL M
;KKM N
}LL 	
publicRR 
voidRR 
UpdateRR 
(RR 
TRR 
entityRR #
)RR# $
{SS 	
_contextTT 
.TT 
SetTT 
<TT 
TTT 
>TT 
(TT 
)TT 
.TT 
UpdateTT $
(TT$ %
entityTT% +
)TT+ ,
;TT, -
}UU 	
}XX 
}YY ∏
àD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\StaffRole.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Entities" *
{		 
[

 
Table

 

(


 
name

 
:

 
$str

 "
)

" #
]

# $
public 

class 
	StaffRole 
: 

BaseEntity '
{ 
public 
string 
StaffRoleCode #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
StaffRoleTitle $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
ICollection 
< 
Staff  
>  !
Staffs" (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} Ë
ÑD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\Staff.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Entities" *
{		 
[

 
Table

 

(


 
name

 
:

 
$str

 
)

 
]

 
public 

class 
Staff 
: 

BaseEntity #
{ 
public 
string 
StaffRoleCode #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
StaffRoleTitle $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
Guid 
StaffRoleId 
{  !
get" %
;% &
set' *
;* +
}, -
public 
	StaffRole 
	StaffRole "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
Guid 
GenUserInfoId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
GeneralUserInfo 
GeneralUserInfo .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
} 
} π
ãD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\ProductBrand.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Entities" *
{ 
public		 

class		 
ProductBrand		 
:		 

BaseEntity		  *
{

 
public 
string 
	BrandCode 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 

BrandNName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
DateTime 
? 
DateOfCreate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
DateTime 
? 
DateOfUpdate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
ICollection 
< 
Product "
>" #
Products$ ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
} 
} ˘
ÜD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\Product.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Entities" *
{ 
public

 

class

 
Product

 
:

 

BaseEntity

 %
{ 
public 
DateTime 
? 
DateOfCreate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
DateTime 
? 
DateOfUpdate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
float 
OriginalPrice "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
ProductCode !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
ProductName !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
StatusId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
Guid 
ProductBrandId "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
ProductBrand 
ProductBrand (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} ë$
ìD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\PracNet7ApiDbContext.cs
	namespace

 	
PracNet7ApiProB01


 
.

 
Model

 !
.

! "
Entities

" *
{ 
public 

static 
class 
MyMoudleInitializer +
{ 
[ 	
ModuleInitializer	 
] 
public 
static 
void 

Initialize %
(% &
)& '
{ 	

AppContext 
. 
	SetSwitch  
(  !
$str! G
,G H
trueI M
)M N
;N O
} 	
} 
public 

class  
PracNet7ApiDbContext %
:& '
	DbContext( 1
{ 
public  
PracNet7ApiDbContext #
(# $
)$ %
{ 	
} 	
	protected  
PracNet7ApiDbContext &
(& '
DbContextOptions' 7
<7 8 
PracNet7ApiDbContext8 L
>L M
optionsN U
)U V
:W X
baseY ]
(] ^
options^ e
)e f
{   	
}!! 	
private## 
string## 
connectionStr## $
=##% &
$str	##' í
;
##í ì
public%% 
DbSet%% 
<%% 
GeneralRole%%  
>%%  !
GeneralRoles%%" .
{%%/ 0
get%%1 4
;%%4 5
set%%6 9
;%%9 :
}%%; <
public&& 
DbSet&& 
<&& 
GeneralUserInfo&& $
>&&$ %
GeneralUserInfo&&& 5
{&&6 7
get&&8 ;
;&&; <
set&&= @
;&&@ A
}&&B C
public'' 
DbSet'' 
<'' 
Customer'' 
>'' 
Customer'' '
{''( )
get''* -
;''- .
set''/ 2
;''2 3
}''4 5
public(( 
DbSet(( 
<(( 
Staff(( 
>(( 
Staff(( !
{((" #
get(($ '
;((' (
set(() ,
;((, -
}((. /
public)) 
DbSet)) 
<)) 
	StaffRole)) 
>)) 
	StaffRole))  )
{))* +
get)), /
;))/ 0
set))1 4
;))4 5
}))6 7
	protected++ 
override++ 
void++ 
OnConfiguring++  -
(++- .#
DbContextOptionsBuilder++. E
optionsBuilder++F T
)++T U
{,, 	
base-- 
.-- 
OnConfiguring-- 
(-- 
optionsBuilder-- -
)--- .
;--. /
optionsBuilder.. 
... 
	UseNpgsql.. $
(..$ %
connectionStr..% 2
)..2 3
;..3 4
}// 	
	protected11 
override11 
void11 
OnModelCreating11  /
(11/ 0
ModelBuilder110 <
modelBuilder11= I
)11I J
{22 	
modelBuilderVV 
.VV 
ApplyConfigurationVV +
(VV+ ,
newVV, /$
GeneralRoleConfigurationVV0 H
(VVH I
)VVI J
)VVJ K
;VVK L
modelBuilderWW 
.WW 
ApplyConfigurationWW +
(WW+ ,
newWW, /(
GeneralUserInfoConfigurationWW0 L
(WWL M
)WWM N
)WWN O
;WWO P
modelBuilderXX 
.XX 
ApplyConfigurationXX +
(XX+ ,
newXX, /!
CustomerConfigurationXX0 E
(XXE F
)XXF G
)XXG H
;XXH I
modelBuilderYY 
.YY 
ApplyConfigurationYY +
(YY+ ,
newYY, /"
StaffRoleConfigurationYY0 F
(YYF G
)YYG H
)YYH I
;YYI J
modelBuilderZZ 
.ZZ 
ApplyConfigurationZZ +
(ZZ+ ,
newZZ, /
StaffConfigurationZZ0 B
(ZZB C
)ZZC D
)ZZD E
;ZZE F
modelBuilder[[ 
.[[ 
ApplyConfiguration[[ +
([[+ ,
new[[, /%
ProductBrandConfiguration[[0 I
([[I J
)[[J K
)[[K L
;[[L M
modelBuilder\\ 
.\\ 
ApplyConfiguration\\ +
(\\+ ,
new\\, / 
ProductConfiguration\\0 D
(\\D E
)\\E F
)\\F G
;\\G H
}]] 	
}^^ 
}__ •
éD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\GeneralUserInfo.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Entities" *
{		 
[

 
Table

 

(


 
name

 
:

 
$str

 (
)

( )
]

) *
public 

class 
GeneralUserInfo  
:! "

BaseEntity# -
{ 
public 
String 
Address 
{ 
get  #
;# $
set% (
;( )
}* +
public 
DateTime 
DateOfBirth #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
DateTime 
? 
DateOfCreate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
DateTime 
? 
DateOfUpdate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
FullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Gender 
{ 
get "
;" #
set$ '
;' (
}) *
public 
Boolean 
IsActive 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 

NationalId  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
PhoneNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
Guid 
	GenRoleId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
GeneralRole 
GeneralRole &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public   
Customer   
Customer    
{  ! "
get  # &
;  & '
set  ( +
;  + ,
}  - .
public&& 
Staff&& 
Staff&& 
{&& 
get&&  
;&&  !
set&&" %
;&&% &
}&&' (
}'' 
}(( Ã
äD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\GeneralRole.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Entities" *
{		 
[ 
Table 

(
 
name 
: 
$str $
)$ %
]% &
public 

class 
GeneralRole 
: 

BaseEntity )
{ 
public 
string 
GenRoleCode !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
GenRoleTitle "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
ICollection 
< 
GeneralUserInfo *
>* +
GeneralUserInfos, <
{= >
get? B
;B C
setD G
;G H
}I J
} 
} ì

™D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\EntityConfigurations\StaffRoleConfiguration.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Entities		" *
.		* + 
EntityConfigurations		+ ?
{

 
public 

class "
StaffRoleConfiguration '
:( )$
IEntityTypeConfiguration* B
<B C
	StaffRoleC L
>L M
{ 
public 
void 
	Configure 
( 
EntityTypeBuilder /
</ 0
	StaffRole0 9
>9 :
builder; B
)B C
{ 	
builder 
. 
HasMany 
( 
p 
=>  
p! "
." #
Staffs# )
)) *
. 
WithOne 
( 
p 
=> 
p 
.  
	StaffRole  )
)) *
. 
HasForeignKey 
( 
p  
=>! #
p$ %
.% &
StaffRoleId& 1
)1 2
;2 3
} 	
} 
} •
¶D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\EntityConfigurations\StaffConfiguration.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Entities		" *
.		* + 
EntityConfigurations		+ ?
{

 
public 

class 
StaffConfiguration #
:$ %$
IEntityTypeConfiguration& >
<> ?
Staff? D
>D E
{ 
public 
void 
	Configure 
( 
EntityTypeBuilder /
</ 0
Staff0 5
>5 6
builder7 >
)> ?
{ 	
builder 
. 
HasOne 
( 
p 
=> 
p  !
.! "
	StaffRole" +
)+ ,
. 
WithMany 
( 
p 
=> 
p  
.  !
Staffs! '
)' (
. 
HasForeignKey 
( 
p  
=>! #
p$ %
.% &
StaffRoleId& 1
)1 2
;2 3
builder 
. 
HasOne 
( 
p 
=> 
p  !
.! "
GeneralUserInfo" 1
)1 2
.   
WithOne   
(   
p   
=>   
p   
.    
Staff    %
)  % &
.!! 
HasForeignKey!! 
<!! 
Staff!! $
>!!$ %
(!!% &
p!!& '
=>!!( *
p!!+ ,
.!!, -
GenUserInfoId!!- :
)!!: ;
;!!; <
}"" 	
}## 
}$$ ø
®D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\EntityConfigurations\ProductConfiguration.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Entities		" *
.		* + 
EntityConfigurations		+ ?
{

 
public 

class  
ProductConfiguration %
:& '$
IEntityTypeConfiguration( @
<@ A
ProductA H
>H I
{ 
public 
void 
	Configure 
( 
EntityTypeBuilder /
</ 0
Product0 7
>7 8
builder9 @
)@ A
{ 	
builder 
. 
HasOne 
( 
p 
=> 
p  !
.! "
ProductBrand" .
). /
. 
WithMany 
( 
b 
=> 
b  
.  !
Products! )
)) *
. 
HasForeignKey 
( 
p  
=>! #
p$ %
.% &
ProductBrandId& 4
)4 5
;5 6
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
DateOfCreate$ 0
)0 1
.1 2

IsRequired2 <
(< =
false= B
)B C
;C D
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
DateOfUpdate$ 0
)0 1
.1 2

IsRequired2 <
(< =
false= B
)B C
;C D
} 	
} 
}   ”
≠D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\EntityConfigurations\ProductBrandConfiguration.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Entities		" *
.		* + 
EntityConfigurations		+ ?
{

 
public 

class %
ProductBrandConfiguration *
:+ ,$
IEntityTypeConfiguration- E
<E F
ProductBrandF R
>R S
{ 
public 
void 
	Configure 
( 
EntityTypeBuilder /
</ 0
ProductBrand0 <
>< =
builder> E
)E F
{ 	
builder 
. 
HasMany 
( 
p 
=>  
p! "
." #
Products# +
)+ ,
. 
WithOne 
( 
b 
=> 
b 
.  
ProductBrand  ,
), -
. 
HasForeignKey 
( 
b  
=>! #
b$ %
.% &
ProductBrandId& 4
)4 5
;5 6
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
DateOfCreate$ 0
)0 1
.1 2

IsRequired2 <
(< =
false= B
)B C
;C D
builder 
. 
Property 
( 
p 
=> !
p" #
.# $
DateOfUpdate$ 0
)0 1
.1 2

IsRequired2 <
(< =
false= B
)B C
;C D
} 	
} 
}   ´
∞D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\EntityConfigurations\GeneralUserInfoConfiguration.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Entities		" *
.		* + 
EntityConfigurations		+ ?
{

 
public 

class (
GeneralUserInfoConfiguration -
:. /$
IEntityTypeConfiguration0 H
<H I
GeneralUserInfoI X
>X Y
{ 
public 
void 
	Configure 
( 
EntityTypeBuilder /
</ 0
GeneralUserInfo0 ?
>? @
builderA H
)H I
{ 	
builder 
. 
HasOne 
( 
p 
=> 
p  !
.! "
GeneralRole" -
)- .
. 
WithMany 
( 
p 
=> 
p  
.  !
GeneralUserInfos! 1
)1 2
. 
HasForeignKey 
( 
p  
=>! #
p$ %
.% &
	GenRoleId& /
)/ 0
;0 1
builder 
. 
HasOne 
( 
p 
=> 
p  !
.! "
Customer" *
)* +
.   
WithOne   
(   
p   
=>   
p   
.    
GeneralUserInfo    /
)  / 0
.!! 
HasForeignKey!! 
<!! 
Customer!! '
>!!' (
(!!( )
p!!) *
=>!!+ -
p!!. /
.!!/ 0
GenUserInfoId!!0 =
)!!= >
;!!> ?
builder)) 
.)) 
HasOne)) 
()) 
p)) 
=>)) 
p))  !
.))! "
Staff))" '
)))' (
.** 
WithOne** 
(** 
p** 
=>** 
p** 
.**  
GeneralUserInfo**  /
)**/ 0
.++ 
HasForeignKey++ 
<++ 
Staff++ $
>++$ %
(++% &
p++& '
=>++( *
p+++ ,
.++, -
GenUserInfoId++- :
)++: ;
;++; <
builder00 
.00 
Property00 
(00 
p00 
=>00 !
p00" #
.00# $
DateOfCreate00$ 0
)000 1
.001 2

IsRequired002 <
(00< =
false00= B
)00B C
;00C D
builder11 
.11 
Property11 
(11 
p11 
=>11 !
p11" #
.11# $
DateOfUpdate11$ 0
)110 1
.111 2

IsRequired112 <
(11< =
false11= B
)11B C
;11C D
}22 	
}33 
}44 •

¨D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\EntityConfigurations\GeneralRoleConfiguration.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Entities		" *
.		* + 
EntityConfigurations		+ ?
{

 
public 

class $
GeneralRoleConfiguration )
:* +$
IEntityTypeConfiguration, D
<D E
GeneralRoleE P
>P Q
{ 
public 
void 
	Configure 
( 
EntityTypeBuilder /
</ 0
GeneralRole0 ;
>; <
builder= D
)D E
{ 	
builder 
. 
HasMany 
( 
p 
=>  
p! "
." #
GeneralUserInfos# 3
)3 4
. 
WithOne 
( 
p 
=> 
p 
.  
GeneralRole  +
)+ ,
. 
HasForeignKey 
( 
p  
=>! #
p$ %
.% &
	GenRoleId& /
)/ 0
;0 1
} 	
} 
} Ê
©D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\EntityConfigurations\CustomerConfiguration.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Entities		" *
.		* + 
EntityConfigurations		+ ?
{

 
public 

class !
CustomerConfiguration &
:' ($
IEntityTypeConfiguration) A
<A B
CustomerB J
>J K
{ 
public 
void 
	Configure 
( 
EntityTypeBuilder /
</ 0
Customer0 8
>8 9
builder: A
)A B
{ 	
builder 
. 
HasOne 
( 
p 
=> 
p  !
.! "
GeneralUserInfo" 1
)1 2
. 
WithOne 
( 
p 
=> 
p 
.  
Customer  (
)( )
. 
HasForeignKey 
< 
Customer '
>' (
(( )
p) *
=>+ -
p. /
./ 0
GenUserInfoId0 =
)= >
;> ?
builder 
. 
Property 
( 
u 
=> !
u" #
.# $
LastPurchaseDate$ 4
)4 5
. 

IsRequired 
( 
false  
)  !
;! "
} 	
} 
}   „

áD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\Customer.cs
	namespace 	
PracNet7ApiProB01
 
. 
Model !
.! "
Entities" *
{		 
[

 
Table

 

(


 
name

 
:

 
$str

 
)

  
]

  !
public 

class 
Customer 
: 

BaseEntity &
{ 
public 
string 
CustomerCode "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
float 
CustomerPoint "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
DateTime 
? 
LastPurchaseDate )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
Guid 
GenUserInfoId !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
GeneralUserInfo 
GeneralUserInfo .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
} 
} ¸
âD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Model\Entities\BaseEntity.cs
	namespace		 	
PracNet7ApiProB01		
 
.		 
Model		 !
.		! "
Entities		" *
{

 
public 

abstract 
class 

BaseEntity $
{ 
[ 	
Key	 
] 
[ 	
DatabaseGenerated	 
( #
DatabaseGeneratedOption 2
.2 3
Identity3 ;
); <
]< =
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
} 
} 
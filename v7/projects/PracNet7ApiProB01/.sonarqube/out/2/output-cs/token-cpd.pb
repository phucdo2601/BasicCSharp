Œ
D:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Utils\Configs\ModelMapperConfig.cs
	namespace 	
PracNet7ApiProB01
 
. 
Utils !
.! "
Configs" )
{ 
public 

class 
ModelMapperConfig "
{ 
public 
static 
Mapper 
IniializeAutoMapper 0
(0 1
)1 2
{ 	
var 
config 
= 
new 
MapperConfiguration 0
(0 1
cfg1 4
=>5 7
{ 
cfg 
. 
	CreateMap 
< 
CreateProductReqDto 1
,1 2
Product3 :
>: ;
(; <
)< =
;= >
cfg 
. 
	CreateMap 
< 
UpdateProductReqDto 1
,1 2
Product3 :
>: ;
(; <
)< =
;= >
cfg 
. 
	CreateMap 
< $
CreateProductBrandReqDto 6
,6 7
ProductBrand8 D
>D E
(E F
)F G
;G H
cfg 
. 
	CreateMap 
< $
UpdateProductBrandReqDto 6
,6 7
ProductBrand8 D
>D E
(E F
)F G
;G H
cfg 
. 
	CreateMap 
< !
CreateStaffRoleReqDto 3
,3 4
	StaffRole5 >
>> ?
(? @
)@ A
;A B
cfg 
. 
	CreateMap 
< !
UpdateStaffRoleReqDto 3
,3 4
	StaffRole5 >
>> ?
(? @
)@ A
;A B
} 
) 
; 
var 
mapper 
= 
new 
Mapper #
(# $
config$ *
)* +
;+ ,
return 
mapper 
; 
} 	
}   
}!! ±
ŒD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Utils\Configs\GeneralConfigs.cs
	namespace 	
PracNet7ApiProB01
 
. 
Utils !
.! "
Configs" )
{		 
public

 

class

 
GeneralConfigs

 
{ 
public 
static 
string  
LogCurrentMethodName 1
(1 2
[2 3
CallerMemberName3 C
]C D
stringE K

methodNameL V
=W X
$strY [
)[ \
{ 	
Console 
. 
	WriteLine 
( 
$"  
$str  5
{5 6

methodName6 @
}@ A
"A B
)B C
;C D
return 

methodName 
; 
} 	
} 
} 
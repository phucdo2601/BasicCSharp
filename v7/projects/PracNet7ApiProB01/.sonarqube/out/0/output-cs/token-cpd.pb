è
òD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Dto\Dtos\StaffRole\UpdateStaffRoleReqDto.cs
	namespace 	
PracNet7ApiProB01
 
. 
Dto 
.  
Dtos  $
.$ %
	StaffRole% .
{ 
public		 

class		 !
UpdateStaffRoleReqDto		 &
{

 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
StaffRoleCode #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
StaffRoleTitle $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} ˚
òD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Dto\Dtos\StaffRole\CreateStaffRoleReqDto.cs
	namespace 	
PracNet7ApiProB01
 
. 
Dto 
.  
Dtos  $
.$ %
	StaffRole% .
{ 
public		 

class		 !
CreateStaffRoleReqDto		 &
{

 
public 
string 
StaffRoleCode #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
StaffRoleTitle $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} ¿
îD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Dto\Dtos\Responses\CommonResponseDto.cs
	namespace 	
PracNet7ApiProB01
 
. 
Dto 
.  
Dtos  $
.$ %
	Responses% .
{ 
public		 

class		 
CommonResponseDto		 "
<		" #
T		# $
>		$ %
{

 
public 
int 

StatusCode 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
Status 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
public 
T 
Data 
{ 
get 
; 
set  
;  !
}" #
} 
} ñ
îD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Dto\Dtos\Product\UpdateProductReqDto.cs
	namespace 	
PracNet7ApiProB01
 
. 
Dto 
.  
Dtos  $
.$ %
Product% ,
{ 
public		 

class		 
UpdateProductReqDto		 $
{

 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
float 
OriginalPrice "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
ProductCode !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
ProductName !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
StatusId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
Guid 
ProductBrandId "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ”
îD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Dto\Dtos\Product\CreateProductReqDto.cs
	namespace 	
PracNet7ApiProB01
 
. 
Dto 
.  
Dtos  $
.$ %
Product% ,
{ 
public		 

class		 
CreateProductReqDto		 $
{

 
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
float 
OriginalPrice "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
required 
string 
ProductCode *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
required 
string 
ProductName *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
public 
required 
string 
StatusId '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
Guid 
ProductBrandId "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ¡
ûD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Dto\Dtos\ProductBrand\UpdateProductBrandReqDto.cs
	namespace 	
PracNet7ApiProB01
 
. 
Dto 
.  
Dtos  $
.$ %
ProductBrand% 1
{ 
public		 

class		 $
UpdateProductBrandReqDto		 )
{

 
public 
Guid 
? 
Id 
{ 
get 
; 
set "
;" #
}$ %
public 
string 
	BrandCode 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 

BrandNName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} Ÿ
ûD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Dto\Dtos\ProductBrand\CreateProductBrandReqDto.cs
	namespace 	
PracNet7ApiProB01
 
. 
Dto 
.  
Dtos  $
.$ %
ProductBrand% 1
{ 
public		 

class		 $
CreateProductBrandReqDto		 )
{

 
public 
required 
string 
	BrandCode (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
required 
string 

BrandNName )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ©
òD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Dto\Dtos\GeneralRole\UpdateGenRoleReqDto.cs
	namespace 	
PracNet7ApiProB01
 
. 
Dto 
.  
Dtos  $
.$ %
GeneralRole% 0
{ 
public		 

class		 
UpdateGenRoleReqDto		 $
{

 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
GenRoleCode "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
? 
GenRoleTitle #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} ´
úD:\LearnSelf\csharp\fundamental\netCore\listFunNetCoreProB01\v7\projects\PracNet7ApiProB01\PracNet7ApiProB01.Dto\Dtos\GeneralRole\CreateGeneralRoleReqDro.cs
	namespace 	
PracNet7ApiProB01
 
. 
Dto 
.  
Dtos  $
.$ %
GeneralRole% 0
{ 
public		 

class		 #
CreateGeneralRoleReqDro		 (
{

 
public 
required 
string 
GenRoleCode *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
required 
string 
GenRoleTitle +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
} 
} 
use DB2017_C13;

Create table BaseItem(
  BaseItemID		int				identity(1,1) not null unique,
  ItemNo		nvarchar(max)	not null,
    Constraint  BaseItem_PK     primary key (BaseItemID)
);

Create table BaseItemName(
  BaseItemNameID	int			identity(1,1) not null unique,
  ItemName		nvarchar(max)	not null,
    Constraint  BaseItemName_PK	Primary Key (BaseItemNameID)
);

Create table BaseItemPrice(
  BaseItemPriceID	int					identity(1,1) not null unique,
  ItemPrice			float				not null,
    Constraint		BaseItemPrice_PK	primary key (BaseItemPriceID),
);

Create table BaseItemPackage(
  BaseItemPackageID		int					identity(1,1) not null unique,
  ItemWeight			float				null,
  ItemCountPerPallet	int					null,
    Constraint			BaseItemPackage_PK	primary key (BaseItemPackageID),
);

Create Table BaseItemExpireDate(
  BaseItemExpireDateID	int						identity(1,1) not null unique,
  ItemExpireDate		datetime2				not null,
   Constraint			BaseItemExpireDate_PK	Primary key (BaseItemExpireDateID),
 );

Create table Item(
  ItemID					int					identity(1,1) not null unique,
  BaseItemId			int					not null,
  BaseItemNameID		int					not null,
  BaseItemPriceID		int					not null,
  BaseItemPackageID		int					not null,
  BaseItemExpireDateID  int					null,
  Created_At			datetime2			not null default(Current_timestamp),
    Constraint			Item_PK				primary key (ItemID),
	Constraint			BaseItem_FK			foreign key	(BaseItemId)
	  references BaseItem(BaseItemID),
	Constraint			BaseItemName_FK			foreign key	(BaseItemNameId)
	  references BaseItemName(BaseItemNameID),
	Constraint			BaseItemPrice_FK			foreign key	(BaseItemPriceId)
	  references BaseItemPrice(BaseItemPriceID),
	Constraint			BaseItemPackage_FK			foreign key	(BaseItemPackageId)
	  references BaseItemPackage(BaseItemPackageID),
	Constraint			BaseItemExpireDate_FK		foreign key (BaseItemExpireDateID)
	  references BaseItemExpireDate(BaseItemExpireDateID)
);

Create VIEW Item_View
AS
 Select I.ItemID, ItemNo, ItemName, ItemWeight, ItemCountPerPallet, ItemPrice, Created_At, ItemExpireDate
 From Item as I
 Inner Join BaseItem as BI on I.BaseItemId = BI.BaseItemID
 Inner Join BaseItemName as BAN on I.BaseItemNameID = BAN.BaseItemNameID
 Inner Join BaseItemPackage as BIW on I.BaseItemPackageID = BIW.BaseItemPackageID
 Inner JOIN BaseItemPrice as BIP on I.BaseItemPriceID = BIP.BaseItemPriceID
 Left JOIN BaseItemExpireDate as BIED on I.BaseItemExpireDateID = BIED.BaseItemExpireDateID

Create Trigger [dbo].[ItemViewInsert] --1
 on [dbo].[Item_View]
 Instead of Insert
 as
Begin
  Declare @MyBaseItemID int; 
  Declare @MyBaseItemNameID int;
  Declare @MyBaseItemPriceID int;
  Declare @MyBaseItemPackageID int;	
  Declare @MyItemNo nvarchar(max); --10
    Set @MyItemNo = (Select ItemNo From Inserted);
  Declare @MyItemName nvarchar(max); 
    Set @MyItemName = (Select ItemName From Inserted);
  Declare @MyItemWeight float;
    Set @MyItemWeight = (Select ItemWeight From Inserted);
  Declare @MyItemCountPerPallet int;
    set @MyItemCountPerPallet = (Select ItemCountPerPallet From Inserted);
  Declare @MyItemPrice float;
    set @MyItemPrice = ( Select ItemPrice From Inserted);
  Declare @MyItemExpireDate datetime2; --20
    set @MyItemExpireDate = (Select ItemExpireDate from Inserted);
  Declare @MyBaseItemExpireDateID int;

  IF Not EXISTS (SELECT * FROM BaseItem WHERE ItemNo=@MyItemNo)
  Begin
      Insert into BaseItem (ItemNo) values (@MyItemNo)
  End
  Set @MyBaseItemID = (SELECT BaseItemID From BaseItem Where ItemNo = @MyItemNo);
  
  IF Not Exists (SELECT * FROM BaseItemName Where ItemName = @MyItemName) --30
  Begin
	  Insert into BaseItemName (ItemName) values (@MyItemName);
  End
  set @MyBaseItemNameID = (Select BaseItemNameId from BaseItemName where ItemName = @MyItemName);
  
  IF Not EXISTS (SELECT * FROM BaseItemPackage WHERE (ItemWeight = @MyItemWeight AND ItemCountPerPallet = @MyItemCountPerPallet))
  Begin
      Insert Into BaseItemPackage (ItemWeight, ItemCountPerPallet) values (@MyItemWeight, @MyItemCountPerPallet)
  End
  Set @MyBaseItemPackageID = (Select BaseItemPackageID from BaseItemPackage where ItemWeight = @MyItemWeight AND ItemCountPerPallet = @MyItemCountPerPallet); --40

  IF Not Exists (Select * From BaseItemPrice where ItemPrice = @MyItemPrice)
  Begin
      Insert into BaseItemPrice (ItemPrice) values (@MyItemPrice)
  End
  Set @MyBaseItemPriceID = (Select BaseItemPriceID from BaseItemPrice where ItemPrice = @MyItemPrice);

  IF @MyItemExpireDate IS NOT NULL AND NOT EXists (Select * From BaseItemExpireDate Where ItemExpireDate = @MyItemExpireDate)
  Begin
	insert into BaseItemExpireDate(ItemExpireDate) values (@MyItemExpireDate) --50
	 Set @MyBaseItemExpireDateID = (Select IDENT_CURRENT('BaseItemExpireDate'));
  End
  Else
  Begin
    Set @MyBaseItemExpireDateID = 
	(SELECT max(BaseItemExpireDateID) FROM (
	Select max(ItemID) as ItemID FROM Item_View 
	where ItemNo = @MyItemNo) AS Hest Inner Join
	Item AS I on Hest.ItemID = I.ItemID);
  END

  IF @MyBaseItemExpireDateID IS NOT NULL
  BEGIN
    IF Not exists 
    (Select * From Item 
      where 
	    BaseItemID = @MyBaseItemID and 
  	    BaseItemNameID = @MyBaseItemNameID and 
	    BaseItemPackageID = @MyBaseItemPackageID and 
	    BaseItemPriceID = @MyBaseItemPriceID and 
	    BaseItemExpireDateID = @MyBaseItemExpireDateID)
    Begin
        insert into Item (BaseItemID, BaseItemNameID, BaseItemPackageID, BaseItemPriceID, BaseItemExpireDateID) values (@MyBaseItemID,@MyBaseItemNameID, @MyBaseItemPackageID, @MyBaseItemPriceID, @MyBaseItemExpireDateID)
    END
  END
  ELSE
  BEGIN
	IF NOT EXISTS
	    (Select * From Item 
      where 
	    BaseItemID = @MyBaseItemID and 
  	    BaseItemNameID = @MyBaseItemNameID and 
	    BaseItemPackageID = @MyBaseItemPackageID and 
	    BaseItemPriceID = @MyBaseItemPriceID)
    Begin
        insert into Item (BaseItemID, BaseItemNameID, BaseItemPackageID, BaseItemPriceID) values (@MyBaseItemID,@MyBaseItemNameID, @MyBaseItemPackageID, @MyBaseItemPriceID)
    END
  END
  Select ItemID From Item 
    where 
	  BaseItemID = @MyBaseItemID and 
	  BaseItemNameID = @MyBaseItemNameID and 
	  BaseItemPackageID = @MyBaseItemPackageID and 
	  BaseItemPriceID = @MyBaseItemPriceID and 
	  BaseItemExpireDateID = @MyBaseItemExpireDateID
End
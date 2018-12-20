export interface iorder
{
  id: number;
  clientId: number;
  voucherId: number;
  status: number;
  beginDate: string;
  endDate: string;
}

export interface ivoucher
{
  id: number;
  tourId: number;
  status: boolean;
  beginDate: string;
  endDate: string;
  inCurrentList: boolean;
  cost: number;
}

export interface searchdata
{
  voucherId: number,
  beginDate: string;
  endDate: string;
}

export interface itour
{
  id: number,
  countryId: number,
  countryName: string,
  hotelId: number,
  hotelName: string,
  resortId: number,
  resortName: string,
}

import {OrderDetailDto} from "./OrderDetailDto";

export interface OrderDto {
  id: number,
  name: string,
  surname: string,
  phone: string,
  orderDetails: OrderDetailDto[]
}

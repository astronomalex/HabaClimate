import {Good} from "./Good";

export interface ShopCartItem {
  id: number,
  good: Good,
  price: number,
  shopCartId: string,
  quantity: number
}


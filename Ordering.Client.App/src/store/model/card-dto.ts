/* eslint-disable no-unused-vars */

/**
  * This is a TypeGen auto-generated file.
  * Any changes made to this file can be lost when this file is regenerated.
  * */

import AddressDto from './address-dto';
import PaymentDto from './payment-dto';
import OrderStatus from './order-status';
import OrderItemDto from './order-item-dto';

interface CardDto {
  id: number;
  customerId: number;
  orderName: string | null | undefined;
  shippingAddress: AddressDto;
  billingAddress: AddressDto;
  payment: PaymentDto;
  status: OrderStatus;
  orderItems: OrderItemDto[];
  description: string | null | undefined;
}
export default CardDto;

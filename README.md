# E-Commerce System

A simple console-based E-Commerce system written in C#.

---

## Features

- ✅ Add products to a customer's cart
- ✅ Check product stock and expiration date
- ✅ Calculate total price, shipping fees based on weight
- ✅ Deduct customer balance upon successful checkout
- ✅ Print detailed receipt and shipment notice
- ✅ Apply object-oriented design with services, repositories, and interfaces

---

## Architecture

- `Entities/` – Core domain models
- `Repositories/` – Data access and management
- `Services/` – Business logic
- `Interfaces/` – Interface definitions

---

## Sample Output

```
** Shipment notice **
1x TV      10000g
5x Cheese      1250g
Total package weight 11.25kg

** Checkout receipt **
1x TV      100
5x Cheese      75
1x Scratch card      20.5
----------------------
Subtotal    195.5
Shipping    5.625
Amount      201.125
Balance after payment  98.875
```

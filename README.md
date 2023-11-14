# minWorkManagerCRM

Users Table
+------------+------------------+
| Field      | Type             |
+------------+------------------+
| UserID     | int (PK)         |
| Username   | varchar          |
| Email      | varchar          |
| Password   | varchar          |
+------------+------------------+

Businesses Table
+--------------+------------------+
| Field        | Type             |
+--------------+------------------+
| BusinessID   | int (PK)         |
| BusinessName | varchar          |
| BusinessType | varchar          |
+--------------+------------------+

UserBusinesses Table
+----------------+------------------+
| Field          | Type             |
+----------------+------------------+
| UserBusinessID | int (PK)         |
| UserID         | int (FK to Users)|
| BusinessID     | int (FK to Businesses)|
| Role           | varchar          |
+----------------+------------------+

Tenants Table (Optional for Multi-Tenancy)
+----------------------+------------------+
| Field                | Type             |
+----------------------+------------------+
| TenantID             | int (PK)         |
| TenantName           | varchar          |
| DatabaseConnectionString | varchar    |
+----------------------+------------------+

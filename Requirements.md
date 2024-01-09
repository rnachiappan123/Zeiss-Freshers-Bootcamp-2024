# Expense Tracker Requirements Document

## User Story

As a working individual, I want a web application to easily keep track of my day-to-day expenses, so that I can store and maintain a record of my expenditures.

## Functional Requirements

1. Input expense data from the user
2. Validate input data
3. Persistent storage of expense data
4. Retrieval of expense data
5. Presentation of expense data

## Non-functional Requirements (Quality Attributes)

1. **Performance**: storage and retrieval of data should be fast (in under 0.5s). UI elements should be responsive.
2. **Security**: expense records can contain sensitive information, thus the storage and transfer of data must be secure.
3. **Interoperability**: users should be able to use the application from a wide range of devices, especially on-the-go.
4. **Reliability**: user data stores should be fault-tolerant to data loss due to equipment failure. (backups)
5. **Availability**: users' expense data should be available even after long time periods. (archives)
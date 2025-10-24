Task 1 – Recipe API

Endpoints

POST /recipes – create a recipe

GET /recipes/{id} – get one recipe

GET /recipes – filter by ?tag=vegan

Validation

Name (required, 3–100 characters)

Ingredients (at least 1)

Steps (at least 1, maximum 50)

Exception handling

When {id} does not exist → return 404 with { traceId, message }.

Logging (Serilog)

Information when a new recipe is created (include recipe ID).

Warning when a filter returns no results.

Error for unexpected exceptions.
/---------------------------------/

Task 2 – Taskboard API (Kanban)

Endpoints

POST /projects/{projectId}/tasks

PATCH /tasks/{id}/status (ToDo → Doing → Done)

GET /projects/{projectId}/tasks?status=Doing

Validation (FluentValidation)

Title required (2–80 characters)

DueDate ≥ UtcNow

Status must be one of {ToDo, Doing, Done}

Exceptions

Invalid status transition → throw InvalidOperationException → 400

Missing project → 404

Logging

Audit log on status change: from → to, and who (dummy userId).

/---------------------------------/

Task 3 – Orders API (Webshop)

Endpoints

POST /orders – create an order

GET /orders/{id}

POST /orders/{id}/pay – simulate payment

Validation

CustomerEmail must be a valid email address

Lines must contain at least 1 item, each with Quantity 1–100

Exceptions

Payment for an already paid order → 409 Conflict

Invalid productId → 400 Bad Request

Logging

Use an enricher that adds OrderId + correlation RequestId to all logs for the request.

/---------------------------------/

Task 4 – Student–Course API

Endpoints

POST /students

POST /courses

POST /enrollments (student enrolls in a course)

GET /students/{id}/courses

Validation (DataAnnotations)

Student: Name (2–60), Email (valid email)

Course: Code (regex ^[A-Z]{3}\d{3}$), Title (required)

Exceptions

Duplicate enrollment → 409

Missing student/course → 404

Logging

Information when a new enrollment is created, include studentId + courseCode.

/---------------------------------/

Task 5 – Sensor API (IoT Measurements)

Endpoints

POST /sensors/{sensorId}/readings

GET /sensors/{sensorId}/readings?from=&to=

Validation

Value must be within the sensor’s configured Min/Max range

RecordedAt must be in UTC and not in the future

Exceptions

Invalid time range (from > to) → 400

Unknown sensor → 404

Logging

Use rolling file sink (daily log files).

Log the number of readings returned in each GET request.

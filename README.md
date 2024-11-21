# AttendanceTracker.API

=============================================================
Roadmap to Build a School Attendance Tracker
=============================================================
1. Requirements Gathering
	Core Features:
		Student and teacher login.
		Role-based dashboards (Admin, Teacher, Student).
		Attendance marking (daily, weekly, monthly).
		Reports (monthly/term-wise attendance summary).
		Notifications for low attendance.
		Export reports to Excel/PDF.
	Optional Features:
		Biometric or QR code-based attendance.
		Mobile app support (future phase).
2. Tech Stack Selection
	Backend:
		ASP.NET Core: For scalable and modern APIs.
		Entity Framework Core: For database interaction with SQL.
	Frontend:
		ReactJS: For responsive UI.
		Material-UI/Chakra-UI: For prebuilt and customizable UI components.
	Database:
		SQL Server: To store attendance and user data.
	Authentication:
		ASP.NET Identity: For role-based authentication and user management.
3. Project Setup
	Set up a Git repository for version control.
	Create a new solution in Visual Studio:
	Backend: ASP.NET Core Web API project.
	Frontend: Create React app using create-react-app or Vite.
	Use SQL Server Management Studio (SSMS) for database setup.
	Use Postman for API testing.
4. Development Plan
	Database Design:

	Tables:
		Users (ID, Name, Role, Email, Password, etc.)
		Students (ID, Name, Grade, Class, etc.)
		Teachers (ID, Name, Subject, etc.)
		Attendance (ID, StudentID, Date, Status, etc.)
		Define relationships between tables.
		Backend Development:

	Set up ASP.NET Core API:
		Configure Entity Framework Core with SQL Server.
	Build endpoints for:
		User login and registration.
		Fetching class and student details.
		Marking attendance.
		Fetching attendance data.
		Implement middleware for authentication and logging.
		
	Frontend Development:

		Set up React project with a folder structure:
			src/components for reusable components.
			src/pages for different pages (Login, Dashboard, etc.).
			src/services for API calls.
		Develop pages:
			Login and Registration.
			Teacher dashboard to mark attendance.
			Admin dashboard to manage users and classes.
			Student dashboard to view attendance.
			
	Integration:

		Connect React frontend with ASP.NET Core APIs.
		Handle API errors and authentication states.
5. Testing
	Unit testing for APIs: Use xUnit or NUnit.
	End-to-end testing for UI: Use Cypress or Playwright.
	Ensure edge cases for role-based access.
6. Deployment
	Use Azure App Service to host the backend.
	Host the React app on Azure Static Web Apps or Netlify.
	Use Azure SQL Database for the database.
=============================================================	
Frameworks/Tools Summary:
	ASP.NET Core: For backend.
	Entity Framework Core: ORM for database interactions.
	ReactJS: Frontend.
	Material-UI: UI framework.
	SQL Server: Database.
	Postman: For API testing.
	GitHub/GitLab: Version control.
	Azure App Service: Deployment.
=============================================================

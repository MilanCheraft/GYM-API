let vue = new Vue({
    el: "#app",
    name: "gym",
    data: {
        baseUrl: "https://localhost:7257/api/",
        loginUrl: "https://localhost:7257/api/User/login",
        registerUrl: "https://localhost:7257/api/User/register",
        currentUser: "",
        newUser: {
            email: "",
            password: "",
            repeatPassword: "",
            firstName: "",
            lastName: "",
            dateOfBirth: null,
            weight: 0,
            length: 0,
            displayName: "",
        },
        newExercise: {
            name: "",
            description: "",
            muscleGroupId: 0,
            reps: 0,
            sets: 0,
            weight: 0,
        },
        newWorkout: {
            name: "",
            userId: "",
            exerciseIds: [],
            duration: 0,
            description: "",
            muscleGroupId: 0,
        },
        updateWorkout: {
            name: "",
            userId: "",
            exerciseIds: [],
            duration: 0,
            description: "",
            muscleGroupId: 0,
            id: 0
        },
        updateExercise: {
            id: 0,
            name: "",
            description: "",
            muscleGroupId: 0,
            reps: 0,
            sets: 0,
            weight: 0,
        },
        updateUser: {
            "userName": "",
            "password": "",
            "email": "",
            "firstName": "",
            "lastName": "",
            "birthDate": null,
            "weight": 0,
            "length": 0,
            "displayName": "",
            "id": ""
        },
        loggedInUser: [],
        email: "",
        password: "",
        loading: false,
        showError: false,
        showFormError: false,
        loggedIn: false,
        errorMessage: "",
        formErroMessage: "",
        token: "",
        tokenObject: null,
        emailAdress: "",
        isTrainer: false,
        workouts: [],
        workoutDetails: null,
        exercises: [],
        muscleGroups: [],
        exerciseDetails: null,
        showAllExercises: false,
        showExerciseDetails: false,
        showAllWorkouts: false,
        showWorkoutDetails: false,
        showRegister: false,
        showProfileInfo: false,
        showEditProfile: false,
        showEditExercise: false,
        showEditWorkout: false,
    },
    created: function () {
        if (sessionStorage.getItem('token') !== null) {
            this.token = window.sessionStorage.getItem('token');
            this.currentUser = window.sessionStorage.getItem('user');
            this.loggedIn = true;
            this.tokenObject = this.decodeToken(this.token);
            const role = this.tokenObject["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
            if (role === "Trainer") {
                this.isTrainer = true;
            }
            this.getMuscleGroups();
            this.hideEverything();
            this.getWorkouts();

        }
    },
    methods: {
        getWorkouts: async function () {
            this.hideEverything();
            const url = `${this.baseUrl}Workouts`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            this.workouts = await axios.get(url, config)
                .then(response => {
                    console.log(response.data.workouts);
                    return response.data.workouts;
                })
                .catch(error => {
                    console.log(error);
                    this.showError = true;
                    this.errorMessage = error.response ? error.response.data.message : error.message;
                    return [];
                });
            this.showAllWorkouts = true;
        },
        showUpdateWorkout: async function (id) {
            await this.getExercises();
            this.hideEverything();

            const url = `${this.baseUrl}Workouts/${id}`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            const workout = await axios.get(url, config)
                .then(response => {
                    console.log(response.data);
                    return response.data;
                })
                .catch(error => {
                    console.log(error);
                    this.showError = true;
                    this.errorMessage = error.response ? error.response.data.message : error.message;
                    return {};
                });
            const exercises = workout.exercises.map(exercise => exercise.id);
            this.updateWorkout = {
                name: workout.name || "",
                userId: workout.user.id || "",
                exerciseIds: exercises || [],
                duration: workout.duration || 0,
                description: workout.description || "",
                muscleGroupId: workout.muscleGroup.id || 0,
                id: workout.id || 0
            };
            this.showEditWorkout = true;
        },
        submitUpdateWorkout: async function () {
            if (!this.validateEditWorkout()) {
                return;
            }
            const url = `${this.baseUrl}Workouts`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            const updateDto = {
                id: this.updateWorkout.id,
                name: this.updateWorkout.name,
                userId: this.updateWorkout.userId,
                exerciseIds: this.updateWorkout.exerciseIds,
                duration: this.updateWorkout.duration,
                description: this.updateWorkout.description,
                muscleGroupId: this.updateWorkout.muscleGroupId
            };
            console.log(updateDto);
            try {
                this.loading = true;
                const response = await axios.put(url, updateDto, config);
                this.loading = false;
                alert("Workout updated!");
                this.getWorkouts();
                this.showEditWorkout = false;
            } catch (error) {
                this.loading = false;
                this.showError = true;
                alert(error.response ? error.response.data.errors : error.message);
            }   
        },
        validateEditWorkout: function () {
            if (!this.updateWorkout.name) {
                alert("Please enter a name for the workout.");
                return false;
            }
            if (!this.updateWorkout.exerciseIds || this.updateWorkout.exerciseIds.length <= 0) {
                alert("Please select at least one exercise.");
                return false;
            }
            if (!this.updateWorkout.duration || this.updateWorkout.duration <= 0) {
                alert("Please enter a valid duration.");
                return false;
            }
            if (!this.updateWorkout.muscleGroupId || this.updateWorkout.muscleGroupId <= 0) {
                alert("Please select a muscle group.");
                return false;
            }
            return true;
        },

        cancelEditWorkout: function () {
            this.getWorkouts();
        },
        createWorkout: async function () {
            if (!this.validateCreateWorkout()) {
                return;
            }
            const userId = this.tokenObject["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
            const createDto = {
                name: this.newWorkout.name,
                userId: userId,
                exerciseIds: this.newWorkout.exerciseIds,
                duration: this.newWorkout.duration,
                description: this.newWorkout.description,
                muscleGroupId: this.newWorkout.muscleGroupId
            };
            const url = `${this.baseUrl}Workouts`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            try {
                this.loading = true;
                const response = await axios.post(url, createDto, config);
                this.loading = false;
                alert("Workout created!");
                this.hideEverything();
                this.getWorkouts();
                this.toggleWorkoutCreateModal();
            } catch (error) {
                this.loading = false;
                this.showError = true;
                alert(error.response ? error.response.data.errors : error.message);
            }
        },
        validateExerciseForm: function () {
            formErroMessage = "";
            if (!this.newExercise.name) {
                alert("Please enter a name for the exercise.");
                return false;
            }
            if (!this.newExercise.description) {
                alert("Please enter a description for the exercise.");
                return false;
            }
            if (!this.newExercise.muscleGroupId || this.newExercise.muscleGroupId <= 0) {
                alert("Please select a muscle group.");
                return false;
            }
            if (!this.newExercise.reps || this.newExercise.reps <= 0) {
                alert("Please enter a valid amount of reps.");
                return false;
            }
            if (!this.newExercise.sets || this.newExercise.sets <= 0) {
                alert("Please enter a valid amount of sets.");
                return false;
            }
            if (!this.newExercise.weight || this.newExercise.weight < 0) {
                alert("Please enter a valid weight.");
                return false;
            }
            this.showFormError = false;
            return true;
        },
        toggleWorkoutCreateModal: function () {
            this.toggleModal("createWorkoutModal");
            this.getExercises();
            this.hideEverything();
            this.getWorkouts();
        },
        validateCreateWorkout: function () {
            if (!this.newWorkout.name) {
                alert("Please enter a name for the workout.");
                return false;
            }
            if (!this.newWorkout.exerciseIds || this.newWorkout.exerciseIds.length <= 0) {
                alert("Please select at least one exercise.");
                return false;
            }
            if (!this.newWorkout.duration || this.newWorkout.duration <= 0) {
                alert("Please enter a valid duration.");
                return false;
            }
            if (!this.newWorkout.muscleGroupId || this.newWorkout.muscleGroupId <= 0) {
                alert("Please select a muscle group.");
                return false;
            }
            return true;
        },
        createExercise: async function () {
            if (!this.validateExerciseForm()) {
                return;
            }
            errorMessage = "";
            const createDto = {
                name: this.newExercise.name,
                description: this.newExercise.description,
                muscleGroupId: this.newExercise.muscleGroupId,
                reps: this.newExercise.reps,
                sets: this.newExercise.sets,
                weight: this.newExercise.weight
            };
            const url = `${this.baseUrl}Exercises`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            try {
                this.loading = true;
                const response = await axios.post(url, createDto, config);
                this.loading = false;
                alert("Exercise created!");
                this.getExercises();
                this.toggleExerciseCreateModal();
            } catch (error) {
                this.loading = false;
                this.showError = true;
                alert(error.response ? error.response.data.errors : error.message);
            }
        },
        getProfileInfo: async function () {
            this.hideEverything();

            const url = `${this.baseUrl}User/Search/${this.currentUser}`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            this.loggedInUser = await axios.get(url, config)
                .then(response => {
                    console.log(response.data);
                    return response.data;
                })
                .catch(error => {
                    console.log(error);
                    this.showError = true;
                    this.errorMessage = error.response ? error.response.data.message : error.message;
                    return [];
                });
            this.showProfileInfo = true;
        },
        UpdateExercise: async function () {
            const url = `${this.baseUrl}Exercises`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            const updateDto = {
                id: this.updateExercise.id,
                name: this.updateExercise.name,
                description: this.updateExercise.description,
                muscleGroupId: this.updateExercise.muscleGroupId,
                reps: this.updateExercise.reps,
                sets: this.updateExercise.sets,
                weight: this.updateExercise.weight
            };
            console.log(updateDto);
            try {
                this.loading = true;
                const response = await axios.put(url, updateDto, config);
                this.loading = false;
                alert("Exercise updated!");
                this.getExercises();
                this.showEditExercise = false;
            } catch (error) {
                this.loading = false;
                this.showError = true;
                alert(error.response ? error.response.data.errors : error.message);
            }
        },
        getMuscleGroups: async function () {
            const url = `${this.baseUrl}MuscleGroups`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            this.muscleGroups = await axios.get(url, config)
                .then(response => {
                    console.log(response.data.muscleGroups);
                    return response.data.muscleGroups;
                })
                .catch(error => {
                    console.log(error);
                    this.showError = true;
                    this.errorMessage = error.response ? error.response.data.message : error.message;
                    return [];
                });
        },
        hideEverything: function () {
            this.showAllExercises = false;
            this.showAllWorkouts = false;
            this.showExerciseDetails = false;
            this.showWorkoutDetails = false;
            this.showProfileInfo = false;
            this.showEditProfile = false;
            this.showEditExercise = false;
            this.showEditWorkout = false;
        },
        getWorkoutDetails: async function (workoutId) {
            this.hideEverything();
            const url = `${this.baseUrl}Workouts/${workoutId}`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            this.workoutDetails = await axios.get(url, config)
                .then(response => {
                    console.log(response.data);
                    return response.data;
                })
                .catch(error => {
                    console.log(error);
                    this.showError = true;
                    this.errorMessage = error.response ? error.response.data.message : error.message;
                    return [];
                });
            this.showWorkoutDetails = true;
        },
        toggleModal: function (modalId) {
            $(`#${modalId}`).modal('toggle');
        },
        toggleRegisterModal: function () {
            this.toggleModal("registerModal");
        },
        toggleExerciseCreateModal: function () {
            this.toggleModal("createExerciseModal");
        },
        cancelEditExercise() {
            this.hideEverything();
            this.getExercises();
        },
        showUpdateExercise: async function (id) {
            this.hideEverything();
            this.showEditExercise = true;
            const url = `${this.baseUrl}Exercises/${id}`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            this.updateExercise = await axios.get(url, config)
                .then(response => {
                    console.log(response.data);
                    return response.data;
                })
                .catch(error => {
                    console.log(error);
                    this.showError = true;
                    this.errorMessage = error.response ? error.response.data.message : error.message;
                    return [];
                });
        },

        editProfile: function () {
            this.hideEverything();

            const date = new Date(this.updateUser.birthDate);
            const formattedDate = date.toISOString().split('T')[0];
            this.updateUser.birthDate = formattedDate;

            this.updateUser.userName = this.loggedInUser.userName;
            this.updateUser.email = this.loggedInUser.userName;
            this.updateUser.firstName = this.loggedInUser.firstName;
            this.updateUser.lastName = this.loggedInUser.lastName;

            this.updateUser.weight = this.loggedInUser.weight;
            this.updateUser.length = this.loggedInUser.length;
            this.updateUser.displayName = this.loggedInUser.displayName;
            this.updateUser.id = this.loggedInUser.userId
            this.showEditProfile = true;
            console.log(this.updateUser);
        },
        cancelEdit: function () {
            this.hideEverything();
            this.showProfileInfo = true;
        },
        updateProfile: async function () {
            console.log(this.updateUser)
            if (!this.validateUserUpdateForm()) {
                return;
            }
            errorMessage = "";
            const date = new Date(this.updateUser.birthDate);
            const formattedDateOfBirth = date.toISOString();
            const updateDto = {
                id: this.updateUser.id,
                email: this.updateUser.email,
                userName: this.updateUser.email,
                password: this.updateUser.password,
                firstName: this.updateUser.firstName,
                lastName: this.updateUser.lastName,
                birthDate: formattedDateOfBirth,
                weight: this.updateUser.weight,
                length: this.updateUser.length,
                displayName: this.updateUser.displayName
            };
            const url = `${this.baseUrl}User`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            try {
                this.loading = true;
                const response = await axios.put(url, updateDto, config);
                this.loading = false;
                alert("Profile updated!");
                this.getProfileInfo();
            } catch (error) {
                this.loading = false;
                this.showError = true;
                alert(error.response ? error.response.data.errors : error.message);
            }

        },
        formateDate: function (date) {
            return new Date(date).toLocaleDateString();
        },
        registerUser: async function () {
            if (!this.validateRegisterForm()) {
                return;
            }
            errorMessage = "";
            const date = new Date(this.updateUser.birthDate);
            const formattedDateOfBirth = date.toISOString();
            const registerDto = {
                email: this.newUser.email,
                password: this.newUser.password,
                firstName: this.newUser.firstName,
                lastName: this.newUser.lastName,
                repeatPassword: this.newUser.repeatPassword,
                birthDate: formattedDateOfBirth,
                weight: this.newUser.weight,
                length: this.newUser.length,
                displayName: this.newUser.displayName
            };
            console.log(registerDto);
            try {
                this.loading = true;
                const response = await axios.post(this.registerUrl, registerDto);
                this.loading = false;
                this.clearForm();
                this.toggleModal("registerModal");
                alert("You have been registered, please log in!");
            } catch (error) {
                this.loading = false;
                this.showError = true;
                alert(error.response ? error.response.data.errors : error.message);
            }
        },
        validateUserUpdateForm: function () {
            formErroMessage = "";
            if (!this.updateUser.email || !this.isValidEmail(this.updateUser.email)) {
                alert("Please enter a valid email address.");
                return false;
            }
            if (!this.updateUser.firstName) {

                alert("Please enter your first name.");
                return false;
            }
            if (!this.updateUser.lastName) {
                alert("Please enter your last name.");
                return false;
            }
            if (!this.updateUser.birthDate || new Date(this.updateUser.birthDate) >= new Date()) {
                alert("Please select a valid date of birth.");
                return false;
            }

            if (!this.updateUser.weight || this.updateUser.weight <= 0) {

                alert("Please enter a valid weight.");
                return false;
            }
            if (!this.updateUser.length || this.updateUser.length <= 0) {
                alert("Please enter a valid length.");
                return false;
            }
            this.showFormError = false;
            return true;
        },
        validateRegisterForm: function () {
            formErroMessage = "";
            if (!this.newUser.email || !this.isValidEmail(this.newUser.email)) {
                alert("Please enter a valid email address.");
                return false;
            }
            if (!this.newUser.password || this.newUser.password.length < 4) {

                alert("Password must be at least 4 characters long.");
                return false;
            }
            if (this.newUser.password !== this.newUser.repeatPassword) {
                alert("Passwords do not match.");
                return false;
            }
            if (!this.newUser.firstName) {

                alert("Please enter your first name.");
                return false;
            }
            if (!this.newUser.lastName) {
                alert("Please enter your last name.");
                return false;
            }
            if (!this.newUser.dateOfBirth || new Date(this.newUser.dateOfBirth) >= new Date()) {
                alert("Please select a valid date of birth.");
                return false;
            }

            if (!this.newUser.weight || this.newUser.weight <= 0) {

                alert("Please enter a valid weight.");
                return false;
            }
            if (!this.newUser.length || this.newUser.length <= 0) {
                alert("Please enter a valid length.");
                return false;
            }
            this.showFormError = false;
            return true;
        },
        isValidEmail: function (email) {
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            return emailRegex.test(email);
        },
        clearForm: function () {
            this.newUser.email = "";
            this.newUser.password = "";
            this.newUser.repeatPassword = "";
            this.newUser.firstName = "";
            this.newUser.lastName = "";
            this.newUser.dateOfBirth = null;
            this.newUser.weight = null;
            this.newUser.length = null;
            this.newUser.displayName = "";
        },
        submitLogin: async function () {
            this.showError = false;
            const loginDto = {
                "email": this.email,
                "password": this.password
            };
            let userToTry = this.email;
            this.loading = true;
            let token = await axios.post(this.loginUrl, loginDto)
                .then(response => {
                    console.log(response);
                    return response.data.bearerToken;
                })
                .catch(error => {
                    this.showError = true;
                    this.errorMessage = error.response ? error.response.data.message : error.message;
                    console.log(error);
                    return null;
                });
            this.loading = false;
            if (token) {
                window.sessionStorage.setItem("token", token);
                this.loggedIn = true;
                this.token = token;
                window.sessionStorage.setItem("user", userToTry);
                this.tokenObject = this.decodeToken(token);
                const role = this.tokenObject["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
                if (role === "Trainer") {
                    this.isTrainer = true;
                }
                this.currentUser = userToTry;
                this.getWorkouts();
            } else {
                this.loggedIn = false;
                this.errorMessage = "Wrong credentials, please try again."
            }
        },
        deleteWorkout: async function (id) {
            if (confirm("Delete workout?")) {
                const url = `${this.baseUrl}Workouts?id=${id}`;
                const config = {
                    headers: {
                        Authorization: `Bearer ${sessionStorage.getItem("token")}`
                    }
                };
                await axios.delete(url, config)
                    .then(response => {
                        console.log(response.data);
                        this.getWorkouts();
                    }).catch(error => console.log(error));
            };
        },
        deleteExercise: async function (id) {
            if (confirm("Delete exercise?")) {
                const url = `${this.baseUrl}Exercises?id=${id}`;
                const config = {
                    headers: {
                        Authorization: `Bearer ${sessionStorage.getItem("token")}`
                    }
                };
                await axios.delete(url, config)
                    .then(response => {
                        console.log(response.data);
                        this.getExercises();
                    }).catch(error => console.log(error));
            }
        },
        getExercises: async function () {
            this.hideEverything();
            const url = `${this.baseUrl}Exercises`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            this.exercises = await axios.get(url, config)
                .then(response => {
                    console.log(response.data.exercises);
                    return response.data.exercises;
                })
                .catch(error => {
                    console.log(error);
                    this.showError = true;
                    this.errorMessage = error.response ? error.response.data.message : error.message;
                    return [];
                });
            this.showAllExercises = true;
        },
        getMuscleGroupName(muscleGroupId) {
            const muscleGroup = this.muscleGroups.find(group => group.id === muscleGroupId);
            return muscleGroup ? muscleGroup.name : 'Unknown';
        },
        getExerciseDetails: async function (exerciseId) {
            this.hideEverything();
            const url = `${this.baseUrl}Exercises/${exerciseId}`;
            const config = {
                headers: {
                    Authorization: `Bearer ${sessionStorage.getItem("token")}`
                }
            };
            this.exerciseDetails = await axios.get(url, config)
                .then(response => {
                    console.log(response.data);
                    return response.data;
                })
                .catch(error => {
                    console.log(error);
                    this.showError = true;
                    this.errorMessage = error.response ? error.response.data.message : error.message;
                    return [];
                });
            this.showExerciseDetails = true;
        },
        submitLogout: function () {
            this.hideEverything();
            this.tokenObject = "";
            window.sessionStorage.clear();
            this.loggedIn = false;
            this.isTrainer = false;
        },
        decodeToken: function (token) {
            var base64Url = token.split('.')[1];
            var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
            var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
                return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
            }).join(''));
            return JSON.parse(jsonPayload);
        },
    }
});
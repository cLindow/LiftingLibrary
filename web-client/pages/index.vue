<template>
  <div class="container">
    <div class="container">
      <!-- Styled -->
      <b-file
        accept="videos\*"
        @change="handleFile"
        placeholder="Choose a file or drop it here..."
        drop-placeholder="Drop file here..."
      ></b-file>
    </div>
    <div>
      <h1 class="title">
        {{message}}
      </h1>
      <b-btn @click="reset">Reset</b-btn>
      <b-btn @click="resetExercises">Reset exercises</b-btn>
    </div>
    <div v-if="exercises">
      <p v-for="e in exercises">
        {{e.name}}
      </p>
    </div>

    <div>
      <b-form-input label="Exercise name" v-model="exerciseName" />
      <b-btn @click="saveExercise">save Exercise</b-btn>
    </div>
  </div>
</template>
<script>
import {mapState, mapActions, mapMutations} from "vuex";
import {BButton, BFormInput} from "bootstrap-vue";
import Axios from "axios";

export default {
  components: {
    BButton,
    BFormInput
  },
  computed: {
    ...mapState({
      message: state => state.message
    }),
    ...mapState('exercises', {
      exercises: state => state.exercises
    })
  },
  data: () => ({
    exerciseName: ""
  }),
  methods: {
    ...mapMutations([
      'reset'
    ]),
    ...mapMutations('exercises', {
      resetExercises: 'reset'
    }),
    ...mapActions('exercises', ['createExercise']),
    async saveExercise() {
      await this.createExercise({exercise: {name: this.exerciseName}});
      this.exerciseName = ""
    },
    async handleFile({target: {files}}){
      if(!files[0]) return;
      const file = files[0]
      const form = new FormData();
      form.append("video", file)
      const result = await Axios.post("http://localhost:5000/api/videos", form);
    }
  }
}

</script>

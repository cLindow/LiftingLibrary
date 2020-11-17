<template>
  <div class="container">
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
    }
  }
}

</script>

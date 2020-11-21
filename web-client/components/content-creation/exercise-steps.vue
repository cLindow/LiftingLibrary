<template>
  <div>
      <div class="d-block text-center">
        <b-card no-body>
          <b-tabs v-model="tabIndex" small card>
            <b-tab title="Exercise Information">
              <b-card>
                <div>
                <b-row class="my-1">
                  <b-col sm="3">
                    <label :for="name">Name of exercise</label>
                  </b-col>
                  <b-col sm="8">
                    <b-form-input v-model="form.name" id="name" placeholder="Exercise name"></b-form-input>
                  </b-col>
                </b-row>
                  <b-row class="my-1">
                    <b-col sm="3">
                      <label :for="description">Description</label>
                    </b-col>
                    <b-col sm="8">
                      <b-form-input v-model="form.description" id="description" placeholder="Description"></b-form-input>
                    </b-col>
                  </b-row>
                  <b-row class="my-1">
                    <b-col sm="3">
                      <label :for="difficulty">Difficulty</label>
                    </b-col>
                    <b-col sm="8">
                      <b-form-select id="difficulty" v-model="form.difficulty" :options="difficultyItems"></b-form-select>
                    </b-col>
                  </b-row>
                  <b-row class="my-1">
                    <b-col sm="3">
                      <label :for="prerequisities">Prerequisites</label>
                    </b-col>
                    <b-col sm="8">
                      <b-form-select id="prerequisities" v-model="form.prerequisites" :options="exerciseItems" multiple></b-form-select>
                    </b-col>
                  </b-row>
                  <b-row class="my-1">
                    <b-col sm="3">
                      <label :for="progressions">Progressions</label>
                    </b-col>
                    <b-col sm="8">
                      <b-form-select v-model="form.progressions" :options="exerciseItems" multiple></b-form-select>
                    </b-col>
                  </b-row>
                  <b-row class="my-1">
                    <b-col sm="3">
                      <label :for="categories">Categories (select many)</label>
                    </b-col>
                    <b-col sm="8">
                      <b-form-select id="categories" v-model="form.categories" :options="categoryItems" multiple></b-form-select>
                    </b-col>
                  </b-row>
                  <b-btn @click="tabIndex++">Continue</b-btn>
              </div>
              </b-card>
            </b-tab>

            <b-tab title="Confirmation">
              <div>
                <b-btn @click="save">Save</b-btn>
              </div>
            </b-tab>
          </b-tabs>
        </b-card>
      </div>
  </div>
</template>

<script>
import {mapGetters,mapState,mapActions, mapMutations} from "vuex";

const initState = () => ({
  tabIndex: 0,
  form: {
    name: "",
    description: "",
    difficulty: "",
    prerequisites: [],
    progressions: [],
    categories: []
  },
})

export default {
  name: "exercise-steps",
  data: initState,
  computed: {
    ...mapState("video-upload", ["active"]),
    ...mapGetters("exercises", ["difficultyItems", "categoryItems", "exerciseItems"])
  },
  watch: {
    "active": function(newValue){
      if(!newValue){
        Object.assign(this.$data, initState())
      }
    }
  },
  methods: {
    ...mapMutations("video-upload", ["reset"]
    ),
    ...mapActions('exercises', ['createExercise']),
    async save() {
      await this.createExercise({form: this.form})
      this.reset()
    }
  }
}
</script>

<style scoped>

</style>

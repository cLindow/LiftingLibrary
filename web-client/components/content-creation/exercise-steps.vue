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
import {mapState,mapActions, mapMutations} from "vuex";

const initState = () => ({
  tabIndex: 0,
  form: {
    name: "",
  },
})

export default {
  name: "exercise-steps",
  data: initState,
  computed: {
    ...mapState("video-upload", ["active"])
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

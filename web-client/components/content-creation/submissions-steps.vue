<template>
  <div>
      <div class="d-block text-center">
        <b-card no-body>
          <b-tabs v-model="tabIndex" small card>

            <b-tab title="Upload Video">
              <b-file
                accept="video/*"
                @change="handleFile"
                placeholder="Choose a file or drop it here..."
                drop-placeholder="Drop file here..."
              ></b-file>
            </b-tab>

            <b-tab title="Exercise Information">
              <b-card>
                <div>
                <b-row class="my-1">
                  <b-col sm="3">
                    <b-form-select label="Select Exercise" v-model="form.exerciseId" :options="exerciseItems"></b-form-select>
                  </b-col>
                </b-row>
                <b-btn @click="tabIndex++" class="mt-3">Continue</b-btn>
              </div>
              </b-card>
            </b-tab>

            <b-tab title="Exercise Information">
              <b-card>
                <div>
                  <b-row class="my-1">
                    <b-col sm="3">
                      <label :for="description">Name of exercise</label>
                    </b-col>
                    <b-col sm="8">
                      <b-form-input v-model="form.description" id="description" placeholder="Description"></b-form-input>
                    </b-col>
                  </b-row>
                </div>
                <b-btn @click="tabIndex++" class="mt-3">Continue</b-btn>
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
import {mapState,mapGetters, mapActions, mapMutations} from "vuex";

const initState = () => ({
    tabIndex: 0,
    form: {
      exerciseId: "",
      video: "",
      description: ""
    }
  })

export default {
  name: "submissions-steps",
  data: initState,
  computed: {
    ...mapGetters("exercises", ["exerciseItems"]),
    ...mapState("video-upload", ["active"]),
  },
  watch: {
    "active": function(newValue){
      if(!newValue){
        Object.assign(this.$data, initState())
      }
    }
  },
  methods: {
    ...mapMutations("video-upload", ["hide"]),
    ...mapActions('video-upload', ["startVideoUpload", "createSubmission"]),
    async handleFile({target: {files}}) {
      if (!files[0]) return;

      const file = files[0]
      const form = new FormData();
      form.append("video", file)
      this.startVideoUpload({form});
      this.tabIndex++;
    },
    save() {
      this.createSubmission({form: this.form})
      this.hide();
    },
  }
}
</script>


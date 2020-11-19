<template>
  <div>
  <template>
    <b-nav-form>
      <b-nav-item @click="toggleActive">Upload</b-nav-item>
    </b-nav-form>
  </template>

  <b-modal size="lg" v-model="active" hide-footer title="Upload movie" no-close-on-backdrop>
    <div class="d-block text-center">
      <b-card no-body>
        <b-tabs v-model="tabIndex" small card>
          <b-tab title="Type of upload">
            <b-btn @click="setType({type: uploadType.EXERCISE})">Exercise</b-btn>
            <b-btn @click="setType({type: uploadType.SUBMISSION})">Submission</b-btn>
          </b-tab>

          <b-tab title="Exercise Information">
            <b-card>              <div>
              <b-row class="my-1">
                <b-col sm="3">
                  <label for="name">Name of exercise</label>
                </b-col>
                <b-col sm="8">
                  <b-form-input v-model="exerciseName" id="name" placeholder="Exercise name"></b-form-input>
                </b-col>
              </b-row>
            </div></b-card>
          </b-tab>

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
                  <label for="name">Name of exercise</label>
                </b-col>
                <b-col sm="8">
                  <b-form-input v-model="exerciseName" id="name" placeholder="Exercise name"></b-form-input>
                </b-col>
              </b-row>
            </div>
              <b-btn @click="incTab">Continue</b-btn>
            </b-card>
          </b-tab>

          <b-tab title="Upload Video">
            <b-file
              accept="video/*"
              @change="handleFile"
              placeholder="Choose a file or drop it here..."
              drop-placeholder="Drop file here..."
            ></b-file>
          </b-tab>

          <b-tab title="Exercise Information">
            <b-card>              <div>
              <b-row class="my-1">
                <b-col sm="3">
                  <label for="name">Exercise description</label>
                </b-col>
                <b-col sm="8">
                  <b-form-input v-model="submission" id="name" placeholder="Exercise name"></b-form-input>
                </b-col>
              </b-row>
              <b-btn @click="incTab" class="mt-3">Save submissions</b-btn>
            </div></b-card>
          </b-tab>

          <b-tab title="Confirmation">
            <div>
              <b-btn @click="save">Save</b-btn>
            </div>
          </b-tab>
        </b-tabs>
      </b-card>
    </div>
    <div class="d flex justify-content-center my-4">
      <b-btn @click="toggleActive">Close</b-btn>
    </div>
  </b-modal>
  </div>
</template>

<script>
import {mapState, mapActions, mapMutations} from "vuex";
import {UPLOAD_TYPE} from "@/data/enum";

export default {
  data: () => ({
    exerciseName: "",
    submission: ""
  }),
  computed: {
    ...mapState("video-upload", ["uploadPromise", "active", "tabIndex"]),
    uploadType() {
      return {
        ...UPLOAD_TYPE
      }
    },
  },
  methods: {
    ...mapMutations("video-upload", ["reset", "toggleActive", "setType", "incTab"]
    ),
    ...mapActions('video-upload', ['startVideoUpload', 'createExercise']),
    async handleFile({target: {files}}) {
      if (!files[0]) return;
      const file = files[0]
      const form = new FormData();
      form.append("video", file)
      this.startVideoUpload({form});
    },
    async save() {
      if (!this.uploadPromise) {
        console.log("upload task is null");
        return
      }
      const video = await this.uploadPromise
      await this.createExercise({
        exercise: {name: this.exerciseName},
        submission: { description: this.submission, video}
      });
      this.exerciseName = ""
      this.submission = ""
      this.reset();
    },
  }
}
</script>

using System;
using Newtonsoft.Json;
using ZendeskSell.Models;

namespace ZendeskSell.SequenceEnrollments {
    public class SequenceEnrollmentResponse {
        public string GetLink() => $"https://app.futuresimple.com/settings/sequences/{ID}";

        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("actor_id")]
        public int ActorID { get; set; }
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
        [JsonProperty("resource_id")]
        public long ResourceID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("current_step_position")]
        public int CurrentStepPosition { get; set; }
        [JsonProperty("finished_at")]
        public DateTimeOffset? FinishedAt { get; set; }
        [JsonProperty("finished_reason")]
        public string FinishedReason { get; set; }
        [JsonProperty("finished_actor_id")]
        public int? FinishedActorID { get; set; }
        [JsonProperty("sequence")]
        public ZendeskSellObjectResponse<Sequence> Sequence { get; set; }
        [JsonProperty("enrollment_steps")]
        public ZendeskSellCollectionResponse<EnrollmentStep> EnrollmentSteps { get; set; }
    }

    public class Sequence {
        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("steps_total")]
        public int StepsTotal { get; set; }
        [JsonProperty("creator_id")]
        public int CreatorID { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class EnrollmentStep {
        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("delay_from_previous_step")]
        public int DelayFromPreviousStep { get; set; }
        [JsonProperty("delay_from_previous_step_unit")]
        public string DelayFromPreviousStepUnit { get; set; }
        [JsonProperty("overdue")]
        public bool Overdue { get; set; }
        [JsonProperty("action_type")]
        public string ActionType { get; set; }
        [JsonProperty("action_properties")]
        public EnrollmentStepActionProperties ActionProperties { get; set; }
        [JsonProperty("action")]
        public ZendeskSellObjectResponse<EnrollmentStepAction> Action { get; set; }
    }
    public class EnrollmentStepActionProperties {
        [JsonProperty("email_template_id")]
        public int EmailTemplateID { get; set; }
        [JsonProperty("is_reply")]
        public bool IsReply { get; set; }
        [JsonProperty("task_content")]
        public Tasks.TaskResponse TaskContent { get; set; }
    }
    public class EnrollmentStepAction {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("executed_at")]
        public DateTimeOffset? ExecutedAt { get; set; }
        [JsonProperty("estimated_execute_at")]
        public DateTimeOffset? EstimatedExecuteAt { get; set; }
        [JsonProperty("failure_reason")]
        public string FailureReason { get; set; }
        [JsonProperty("task_content")]
        public string TaskContent { get; set; }
        [JsonProperty("task_id")]
        public int? TaskID { get; set; }
    }
}

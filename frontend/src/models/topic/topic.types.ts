import { z } from 'zod'

import {
	CreateTopicSchema,
	TopicSchema,
	UpdateTopicSchema,
} from '~models/topic/topic.schema'

export type ITopic = z.infer<typeof TopicSchema>

export type ICreateTopic = z.infer<typeof CreateTopicSchema>

export type IUpdateTopic = z.infer<typeof UpdateTopicSchema>

export type UseTopics = UseModelOptions

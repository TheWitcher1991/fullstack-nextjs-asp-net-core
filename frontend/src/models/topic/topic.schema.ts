import { z } from 'zod'

import { zShape } from '~packages/schemas'

export const BaseTopicSchema = z.object({
	title: zShape.title,
})

export const TopicSchema = BaseTopicSchema.extend({
	id: zShape.id,
})

export const CreateTopicSchema = BaseTopicSchema

export const UpdateTopicSchema = BaseTopicSchema

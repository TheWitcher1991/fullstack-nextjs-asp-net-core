import { Flex, Text } from '@gravity-ui/uikit'

import { IBook } from '~models/book'

import { CardImage, Spacing } from '~packages/ui'
import { staticPath, trimText } from '~packages/utils'

interface BookOverviewProps {
	book: IBook
}

export default function BookOverview({ book }: BookOverviewProps) {
	return (
		<>
			<Flex gap={6}>
				<CardImage
					height={290}
					width={189}
					src={staticPath(book.imagePath)}
				/>
				<Flex direction={'column'}>
					<Text variant={'body-3'} color={'secondary'}>
						{book.author.fullName}
					</Text>
					<Spacing v={'xss'} />
					<Text variant={'display-1'}>{book.title}</Text>
				</Flex>
			</Flex>
		</>
	)
}

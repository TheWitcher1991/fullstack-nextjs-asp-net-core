'use client'

import { Skeleton } from '@gravity-ui/uikit'
import NextImage, { ImageProps } from 'next/image'
import { useState } from 'react'

export const Image = ({
	src,
	width,
	height,
	alt,
	fill,
	quality,
	priority,
	style,
}: ImageProps) => {
	const [isLoaded, setIsLoaded] = useState(false)

	return (
		<>
			{!isLoaded && (
				<Skeleton
					style={{
						width: width,
						height: height,
						flex: `0 0 ${width}px`,
					}}
				/>
			)}
			<NextImage
				style={style}
				src={src}
				unoptimized={true}
				width={width}
				height={height}
				alt={alt}
				onLoad={() => setIsLoaded(true)}
				quality={quality}
				fill={fill}
				priority={priority}
			/>
		</>
	)
}
